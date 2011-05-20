using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data.Common;
using System.Reflection;

namespace SqlToolkit
{
	public class ReadMapBuilder<TModel, TTable>
		where TTable : SqlTable
	{
		private TTable _table;
		private List<FieldItem> _fields = new List<FieldItem>();
		private List<ColumnItem> _columns = new List<ColumnItem>();
		
		public ReadMapBuilder(TTable table)
		{
			_table = table;
		}
		
		public ReadMapBuilder<TModel, TTable> Map<TProperty>(Expression<Func<TModel, TProperty>> field, Expression<Func<TTable, Column<TProperty>>> column)
		{
			int columnIndex = AddColumn(column);
			
			_fields.Add(new FieldItem(
				GetProperty(field),
				null,
				columnIndex));
			
			return this;
		}
		
		public ReadMapBuilder<TModel, TTable> Map<TProperty, TCol1, TCol2>(
			Expression<Func<TModel, TProperty>> field,
			Func<TCol1, TCol2, TProperty> converter,
			Expression<Func<TTable, Column<TCol1>>> column1,
			Expression<Func<TTable, Column<TCol2>>> column2)
		{
			int column1Index = AddColumn(column1);
			int column2Index = AddColumn(column2);
			
			_fields.Add(new FieldItem(
				GetProperty(field),
				converter.Method,
				column1Index, column2Index));
			
			return this;
		}
		
		
		private int AddColumn<TProperty>(Expression<Func<TTable, Column<TProperty>>> exp)
		{
			Column<TProperty> column = exp.Compile()(_table);

			int index = _columns.FindIndex((i) => {return i.Name == column.Name;});
			if(index != -1)
				return index;

			_columns.Add(new ColumnItem(column.Name, typeof(TProperty)));
			
			return _columns.Count - 1;
		}
		
		public ReadMapper<TModel, TTable> Compile()
		{
			ParameterExpression pReader = Expression.Parameter(typeof(DbDataReader));
			ParameterExpression pDestination = Expression.Parameter(typeof(TModel));
			
			List<ParameterExpression> variables = new List<ParameterExpression>();
			List<Expression> body = new List<Expression>();
			
			CreateReadColums(pReader, variables, body);
			CreateSetFields(pDestination, variables, body);

			BlockExpression block = Expression.Block(variables, body);

			string reqColumns = _table.CreateColumnList(_columns.Select((col) => col.Name));

			Action<DbDataReader, TModel> loader = Expression
				.Lambda<Action<DbDataReader, TModel>>(block, pReader, pDestination)
				.Compile();

			return new ReadMapper<TModel, TTable>(_table, reqColumns, loader);
		}

		private void CreateSetFields(ParameterExpression pDestination, List<ParameterExpression> variables, List<Expression> body)
		{
			int NFields = _fields.Count;
			for (int i = 0; i < NFields; i++)
				body.Add(Expression.Call(
					pDestination,
					_fields[i].Field.GetSetMethod(),
					CreateSourceArgument(variables, i)));
		}

		private Expression CreateSourceArgument(List<ParameterExpression> variables, int i)
		{
			if (_fields[i].Converter == null)
				return variables[_fields[i].ArgColumns[0]];

			List<ParameterExpression> convParams = new List<ParameterExpression>();
			foreach (int argIndex in _fields[i].ArgColumns)
				convParams.Add(variables[argIndex]);
			return Expression.Call(_fields[i].Converter, convParams);
		}

		private void CreateReadColums(ParameterExpression pReader, List<ParameterExpression> variables, List<Expression> body)
		{
			int NCols = _columns.Count;
			for (int i = 0; i < NCols; i++)
			{
				ParameterExpression variable = Expression.Variable(_columns[i].Type, "column" + i.ToString());
				variables.Add(variable);

				BinaryExpression assign = Expression.Assign(variable,
					DbDataReaderHelper.CreateReader(pReader, _columns[i].Type, i));
				body.Add(assign);
			}
		}
		
		private static PropertyInfo GetProperty<TProperty>(Expression<Func<TModel, TProperty>> expression)
		{
			var memberExpression = expression.Body as MemberExpression;
			if (memberExpression == null)
				throw new ArgumentException("Lambda was not a member access");
			var propertyInfo = memberExpression.Member as PropertyInfo;
			if (propertyInfo == null)
				throw new ArgumentException("Lambda was not a property access");
			if (expression.Parameters.Count != 1 || expression.Parameters[0] != memberExpression.Expression)
				throw new ArgumentException("Property was not invoked on parameter");
			if (!propertyInfo.CanWrite)
				throw new ArgumentException("Property is read-only");
			return propertyInfo;
		}

		public static Action<TModel, TProperty> GetValueSetter<TProperty>(PropertyInfo propertyInfo)
		{
			var instance = Expression.Parameter(typeof(TModel), "i");
			var castedInstance = Expression.ConvertChecked(instance, propertyInfo.DeclaringType);
			var argument = Expression.Parameter(typeof(TProperty), "a");
			var setterCall = Expression.Call(
				castedInstance,
				propertyInfo.GetSetMethod(),
				Expression.Convert(argument, propertyInfo.PropertyType));
			
			return Expression.Lambda<Action<TModel, TProperty>>(setterCall, instance, argument).Compile();
		}

		public static Func<TModel, TProperty> GetValueGetter<TProperty>(PropertyInfo propertyInfo)
		{
			var instance = Expression.Parameter(typeof(TModel), "i");
			var castedInstance = Expression.ConvertChecked(instance, propertyInfo.DeclaringType);
			var property = Expression.Property(castedInstance, propertyInfo);
			var convert = Expression.Convert(property, typeof(TProperty));
			var expression = Expression.Lambda(convert, instance);
			return (Func<TModel, TProperty>)expression.Compile();
		}
	}
}

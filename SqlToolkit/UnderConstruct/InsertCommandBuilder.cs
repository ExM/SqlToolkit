using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data.Common;

namespace SqlToolkit
{
	public class InsertCommandBuilder<TConn, TCmd, TTable>
		where TConn: DbConnection
		where TCmd: DbCommand
	{

		public InsertCommandBuilder(DbProvider<TConn, TCmd> provider, TTable tableSchema)
		{

		}


		public ArgCursor<TModel> Arg<TModel>()
		{

			return new ArgCursor<TModel>(this);
		}


		public Func<TConn, TArg, TCmd> Compile<TArg>()
		{


			return null;
		}

		public Func<TConn, TArg1, TArg2, tArg3, TCmd> Compile<TArg1, TArg2, tArg3>()
		{


			return null;
		}

		public class ArgCursor<TModel>
		{

			InsertCommandBuilder<TConn, TCmd, TTable> _builder;

			public ArgCursor(InsertCommandBuilder<TConn, TCmd, TTable> builder)
			{
				_builder = builder;
			}

			public ArgCursor<TModel> Map<TProperty>(
				Expression<Func<TTable, Column<TProperty>>> column,
				Expression<Func<TModel, TProperty>> field)
			{

				return this;
			}

			public InsertCommandBuilder<TConn, TCmd, TTable> Parent
			{
				get
				{
					return _builder;
				}
			}
		}
	}
}

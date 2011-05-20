using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data.Common;
using System.Reflection;

namespace SqlToolkit
{
	public class ReadMapper<TModel, TTable>: IReadMapper<TModel, TTable>
		where TTable : SqlTable
	{
		private TTable _table;
		private Action<DbDataReader, TModel> _loader;
		private string _reqColumns;
		
		internal ReadMapper(TTable table, string reqColumns, Action<DbDataReader, TModel> loader)
		{
			_table = table;
			_reqColumns = reqColumns;
			_loader = loader;
		}
		
		public string RequiredColumns
		{
			get
			{
				return _reqColumns;
			}
		}

		public void LoadInstance(DbDataReader reader, TModel model)
		{
			_loader(reader, model);
		}
	}
}

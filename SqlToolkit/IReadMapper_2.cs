using System;
using System.Data.Common;

namespace SqlToolkit
{
	public interface IReadMapper<TModel, TTable>
		where TTable : SqlTable
	{
		void LoadInstance(DbDataReader reader, TModel model);
		string RequiredColumns { get; }
	}
}


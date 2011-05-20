using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlToolkit
{
	public class SqlTable
	{
		public DbSettings DbSettings {get; private set;}
		public string Name {get; private set;}

		public SqlTable(DbSettings settings, string name)
		{
			DbSettings = settings;
			Name = name;
		}

		public string CreateColumnList(IEnumerable<string> columns)
		{
			return string.Join(",", columns.Select((col) => DbSettings.GetEscapedName(col)));
		}
	}
}

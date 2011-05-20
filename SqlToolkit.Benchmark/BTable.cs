using System;
using ExM.SqlToolkit;

namespace SqlToolkit.Benchmark
{
	public class BTable: SqlTable
	{
		public BTable(DbSettings settings, string name)
			: base(settings, name)
		{
		}
		
		public readonly Column<int> Id = new Column<int>("id");
		public new readonly Column<string> Name = new Column<string>("name");
		public readonly Column<string> NameNull = new Column<string>("namenull");
		public readonly Column<int?> Rooms = new Column<int?>("rooms");
		public readonly Column<int?> RoomsNull = new Column<int?>("roomsnull");
		public readonly Column<bool> Verify = new Column<bool>("verify");
		
		public static readonly BTable Instance = new BTable(DbSettings.MSSQL, "table");
	}
}


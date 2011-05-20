using System;
using SqlToolkit;

namespace SqlToolkit.Test
{
	public class MyTable: SqlTable
	{
		public MyTable(DbSettings settings, string name)
			:base(settings, name)
		{
		}
		
		public readonly Column<int> Id = new Column<int>("id");
		public new readonly Column<string> Name = new Column<string>("name");
		public readonly Column<int?> Rooms = new Column<int?>("rooms");
		public readonly Column<double?> Longitude = new Column<double?>("lon");
		public readonly Column<double?> Lotitude = new Column<double?>("lot");
		public readonly Column<bool> Verify = new Column<bool>("verify");
		
		public static readonly MyTable Instance = new MyTable(DbSettings.MSSQL, "table");
	}
}


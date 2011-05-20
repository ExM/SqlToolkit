using System;
using System.Data.Common;

namespace SqlToolkit.Benchmark
{
	public class HandMapper: IReadMapper<BDataObject, BTable>
	{
		public HandMapper()
		{
		}

		public void LoadInstance(DbDataReader reader, BDataObject model)
		{
			int column0 = reader.GetInt32(0);
			string column1 = reader.GetString(1);
			string column2 = reader.GetString(2);
			
			int? column3;
			if (reader.IsDBNull(3))
				column3 = null;
			else
				column3 = reader.GetInt32(3);
			
			int? column4;
			if (reader.IsDBNull(4))
				column4 = null;
			else
				column4 = reader.GetInt32(4);
			
			bool column5 = reader.GetBoolean(5);
			
			model.Id = column0;
			model.Name = column1;
			model.NameNull = column2;
			model.Rooms = column3;
			model.RoomsNull = column4;
			model.Verify = column5;
		}

		public string RequiredColumns
		{
			get { throw new NotImplementedException(); }
		}
	}
}


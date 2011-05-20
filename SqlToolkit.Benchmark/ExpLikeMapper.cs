using System;
using System.Data.Common;

namespace SqlToolkit.Benchmark
{
	public class ExpLikeMapper: IReadMapper<BDataObject, BTable>
	{
		private Action<DbDataReader, BDataObject> _loader;
		
		public ExpLikeMapper()
		{
			_loader = InternalLoadInstance;
		}
		
		private void InternalLoadInstance(DbDataReader reader, BDataObject model)
		{
			int column0 = reader.GetInt32(0);
			string column1 = reader.GetString(1);
			string column2 = reader.GetString(2);
			int? column3 = GetInt32(reader, 3);
			int? column4 = GetInt32(reader, 4);
			bool column5 = reader.GetBoolean(5);
			
			model.Id = column0;
			model.Name = column1;
			model.NameNull = column2;
			model.Rooms = column3;
			model.RoomsNull = column4;
			model.Verify = column5;
		}
		
		private static Int32? GetInt32(DbDataReader reader, int index)
		{
			if (reader.IsDBNull(index))
				return null;
			else
				return reader.GetInt32(index);
		}

		public void LoadInstance(DbDataReader reader, BDataObject model)
		{
			_loader(reader, model);
		}


		public string RequiredColumns
		{
			get { throw new NotImplementedException(); }
		}
	}
}


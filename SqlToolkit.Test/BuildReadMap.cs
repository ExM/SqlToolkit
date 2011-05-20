using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Data.Common;
using SqlToolkit;

namespace SqlToolkit.Test
{
	[TestFixture]
	public class BuildReadMap
	{
		[Test]
		public void Test()
		{
			IReadMapper<MyDataObject, MyTable> mapper = new ReadMapBuilder<MyDataObject, MyTable>(MyTable.Instance)
				.Map(dObj => dObj.Id,		t => t.Id)
				.Map(dObj => dObj.Name,		t => t.Name)
				.Map(dObj => dObj.Rooms,	t => t.Rooms)
				.Map(dObj => dObj.Verify,	t => t.Verify)
				.Compile();
			
			DataReaderCap reader = new DataReaderCap(new object[] {(int)123, "text Name", null, true});
			
			MyDataObject model = new MyDataObject();
			mapper.LoadInstance(reader, model);
			
			Assert.AreEqual(123, model.Id);
			Assert.AreEqual("text Name", model.Name);
			Assert.IsNull(model.Rooms);
			Assert.IsTrue(model.Verify);
		}
		
		[Test]
		public void LoadPoint()
		{
			IReadMapper<MyDataObject, MyTable> mapper = new ReadMapBuilder<MyDataObject, MyTable>(MyTable.Instance)
				.Map(dObj => dObj.Id, t => t.Id)
				.Map(dObj => dObj.Location,
					MyDataObject.ReadGeoPoint, t => t.Longitude, t => t.Lotitude)
				.Compile();
			
			DataReaderCap reader = new DataReaderCap(new object[] {(int)123, 0.5d, 0.2d});
			
			MyDataObject model = new MyDataObject();

			mapper.LoadInstance(reader, model);
			
			Assert.IsNotNull(model.Location);
			Assert.AreEqual(0.5d, model.Location.Value.Longitude);
			Assert.AreEqual(0.2d, model.Location.Value.Lotitude);
		}

		[Test]
		public void CreateParams()
		{
			//DbCommand cmd;
			//cmd.Parameters
			/*
			IParamMapper<MyDataObject, MyTable> mapper = new ParamMapBuilder<MyDataObject, MyTable>(MyTable.Instance)
				.Map(t => t.Id, dObj => dObj.Id)
				.Map(t => t.Types, dObj => dObj.Types) // t.Types - функция сохранения связанных полей(списков)
				.Map(t => t.Longitude, GetLongitude, dObj => dObj.Location)
				.Map(t => t.Lotitude, GetLotitude, dObj => dObj.Location)
				.Compile();
			*/
		}

	}
}

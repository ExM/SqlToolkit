using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Data.Common;
using SqlToolkit;
using System.Data.SqlClient;

namespace SqlToolkit.Test
{
	[TestFixture]
	public class BuildInsertCommand
	{
		[Test]
		public void Test()
		{
			//InsertCommandBuilder<MyTable> insertBuilder = new DbProvider().Insert(MyTable.Instance);

			Func<SqlConnection, MyDataObject, MyDataObject, GeoPoint, SqlCommand> cmdFactory =
				new DbProvider<SqlConnection, SqlCommand>().Insert(MyTable.Instance) // -- InsertCommandBuilder<MyTable> insertBuilder
				.Arg<MyDataObject>()
					.Map(t => t.Id, o => o.Id)
					.Map(t => t.Name, o => o.Name)
					.Map(t => t.Longitude, o => o.Location.Value.Longitude)
					.Parent
				.Arg<MyDataObject>()
					.Map(t => t.Rooms, o => o.Rooms)
					.Map(t => t.Verify, o => o.Verify)
					.Parent
				.Arg<GeoPoint>()
					.Map(t => t.Lotitude, p => p.Lotitude)
					.Parent
				.Compile<MyDataObject, MyDataObject, GeoPoint>();

			SqlCommand cmd = cmdFactory(null, null, null, new GeoPoint());
			
			string cmdText = "INSERT [mytable] ([id],[name],[rooms],[verify],[lon],[lot]) VALUES (@p0,@p1,@p2,@p3,@p4,@p5)";

			Assert.AreEqual(cmdText, cmd.CommandText);
		}
	}
}

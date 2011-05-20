using System;

namespace SqlToolkit.Test
{
	public class MyDataObject
	{
		public int Id {get; set;}
		
		public string Name {get; set;}
		
		public int? Rooms {get; set;}
		
		public GeoPoint? Location {get; set;}
		
		public bool Verify {get; set;}
		
		public MyDataObject ()
		{
		}
		
		public static GeoPoint? ReadGeoPoint(double? lon, double? lot)
		{
			if(lon.HasValue && lot.HasValue)
				return new GeoPoint(lon.Value, lot.Value);
			else
				return null;
		}
	}
}


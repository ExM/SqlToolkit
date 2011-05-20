using System;
namespace SqlToolkit.Test
{
	public struct GeoPoint
	{
		public double Longitude;
		public double Lotitude;
		
		public GeoPoint(double lon, double lot)
		{
			Longitude = lon;
			Lotitude = lot;
		}
	}
}


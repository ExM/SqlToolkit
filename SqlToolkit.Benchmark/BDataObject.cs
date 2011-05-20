using System;

namespace SqlToolkit.Benchmark
{
	public class BDataObject
	{
		public int Id {get; set;}
		
		public string Name {get; set;}
		
		public string NameNull {get; set;}
		
		public int? Rooms {get; set;}
		
		public int? RoomsNull {get; set;}
		
		public bool Verify {get; set;}
		
		public BDataObject ()
		{
		}
	}
}


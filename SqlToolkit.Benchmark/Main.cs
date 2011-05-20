using System;
using SqlToolkit.Test;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.Common;
using System.Linq;

namespace SqlToolkit.Benchmark
{
	class MainClass
	{
		
		private static IReadMapper<BDataObject, BTable> expMapper;
		private static IReadMapper<BDataObject, BTable> handMapper;
		private static IReadMapper<BDataObject, BTable> expLikeMapper;
		
		private static DataReaderCap reader;
		private static BDataObject model;
		
		public static void Main (string[] args)
		{
			
			expMapper = new ReadMapBuilder<BDataObject, BTable>(BTable.Instance)
				.Map(dObj => dObj.Id, t => t.Id)
				.Map(dObj => dObj.Name, t => t.Name)
				.Map(dObj => dObj.NameNull, t => t.NameNull)
				.Map(dObj => dObj.Rooms, t => t.Rooms)
				.Map(dObj => dObj.RoomsNull, t => t.RoomsNull)
				.Map(dObj => dObj.Verify, t => t.Verify)
				.Compile();
			
			handMapper = new HandMapper();
			expLikeMapper = new ExpLikeMapper();
			
			reader = new DataReaderCap(	new object[] {(int)123, "text Name", null, (int)321, null, true});
			model = new BDataObject();
			
			Process.GetCurrentProcess().ProcessorAffinity = (System.IntPtr)1;
			
			handMapper.LoadInstance(reader, model);
			expLikeMapper.LoadInstance(reader, model);
			expMapper.LoadInstance(reader, model);
			
			double sh = Measure("Empty", 10000000, EmptyAction); 
			Console.WriteLine();
			double h =  Measure(" Hand", 10000000, HandAction);
			Console.WriteLine("(1)");
			double el = Measure(" ExpL", 10000000, ExpLikeAction);
			Console.WriteLine("({0:G4})", el/h);
			double ex = Measure("  Exp", 10000000, ExpAction);
			Console.WriteLine("({0:G4})", ex/h);
		}

		public static double Measure(string title, int repeats, Action action)
		{
			action();
			
			long start = Stopwatch.GetTimestamp();
			for (int j = 0; j < repeats; j++)
				action();
			long t = Stopwatch.GetTimestamp() - start;
			
			double m = (double)t / repeats / Stopwatch.Frequency;
			
			Console.Write("{0}: {1:G4} mcS ", title, (m)*1000000);
			
			return m;
		}

		public static void EmptyAction()
		{
			reader.GetInt32(0);
			reader.GetString(1);
			reader.GetString(2);
			reader.IsDBNull(3);
			reader.GetInt32(3);
			reader.IsDBNull(4);
			reader.GetBoolean(5);
		}
		
		public static void HandAction()
		{
			handMapper.LoadInstance(reader, model);
		}
		
		public static void ExpLikeAction()
		{
			expLikeMapper.LoadInstance(reader, model);
		}
		
		public static void ExpAction()
		{
			expMapper.LoadInstance(reader, model);
		}
	}
}


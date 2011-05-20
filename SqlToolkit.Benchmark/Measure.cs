using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ExM.SqlToolkit.Benchmark
{
	/*
	public class Measure
	{
		public double Average { get; private set; }
		public double Reliability { get; private set; }
		public double MinPrecision { get; private set; }

		public Measure()
		{
			Average = double.NaN;
			MinPrecision = double.NaN;
		}
		
		/// <summary>
		/// Добавить в гистограмму один замер
		/// </summary>
		/// <param name="hist">
		/// гистограмма <see cref="SortedList<System.Double, System.Int32>"/>
		/// </param>
		/// <param name="sums">
		/// повторов в замере <see cref="System.Int32"/>
		/// </param>
		/// <param name="action">
		/// тестируемый участок <see cref="Action"/>
		/// </param>
		public static void AppendMeasure(SortedList<double, int> hist, int sums, Action action)
		{
			long start = Stopwatch.GetTimestamp();
			for (int j = 0; j < sums; j++)
				action();
			long t = Stopwatch.GetTimestamp() - start;
			
			double m = (double)t / sums / Stopwatch.Frequency;
			
			int ex;
			if (hist.TryGetValue(m, out ex))
				hist[m] = ex + 1;
			else
				hist.Add(m, 1);
		}
		
		public static Tuple<double, double> Run(int repeats, int sums, Action action)
		{
			Tuple<double, double> result = new Tuple<double, double>(0,0);
			
			double[] x = new double[repeats];
			for (int r = 0; r < repeats; r++)
			{
				long start = Stopwatch.GetTimestamp();
				for (int j = 0; j < sums; j++)
					action();
				long t = Stopwatch.GetTimestamp() - start;
				double m = (double)t / sums / Stopwatch.Frequency;
				x[r] = m;
			}
			
			double av = 0;
			for (int r = 0; r < repeats; r++)
			{
				av += x[r]/repeats;
			}
			
			double d = 0;
			for (int r = 0; r < repeats; r++)
			{
				d += (x[r] - av)*(x[r] - av)/repeats;
			}
			d = Math.Sqrt(d);
			
			Console.Write("av:{0} ns", av * 1000000000);
			Console.Write("~{0} ns", 3 * d * 1000000000);
			Console.WriteLine(" d:{0} ns",  d * 1000000000);
			
			return result;
		}
		
		
		public static SortedList<double, int>[] Run(int repeats, int sums, Action[] actions)
		{
			int N = actions.Length;
			SortedList<double, int>[] hists = new SortedList<double, int>[N];
			for(int i = 0; i<N; i++)
				hists[i] = new SortedList<double, int>();
			
			
			Console.Write(">");
			int curPoint = 0;
			
			for (int r = 0; r < repeats; r++)
			{
				if((double)r / repeats * 100 > curPoint)
				{
					curPoint++;
					Console.Write("\b\b\b\b\b");
					Console.Write("{0}%", curPoint);
				}
				for(int i = 0; i<N; i++)
					AppendMeasure(hists[i], sums, actions[i]);
			}
			Console.WriteLine(" completed");
			return hists;
		}
		
		public static Measure Analize(SortedList<double, int> hist, int repeats, int sums)
		{
			List<KeyValuePair<double, int>> copyHist = hist.ToList();
			Measure result = new Measure();
			result.MinPrecision = 1d / (copyHist[0].Key * sums * Stopwatch.Frequency);

			int columns = copyHist.Count;

			KeyValuePair<double, int> prev = copyHist[0];
			double averSum = prev.Key * prev.Value / repeats;
			int reliability = prev.Value;

			for (int i = 1; i < columns; i++)
			{
				KeyValuePair<double, int> cur = copyHist[i];
				double f = (double)(prev.Value + cur.Value) / (2 * (cur.Key - prev.Key) * sums * Stopwatch.Frequency);
				
				double curReliability = (double)reliability / repeats;
				if (f < 1 && curReliability > 0.75d)
					break;

				averSum += cur.Key * cur.Value / repeats;
				reliability += cur.Value;
				prev = cur;
			}

			result.Average = averSum;
			result.Reliability = (double)reliability / repeats;
			return result;
		}
	}
	*/
}

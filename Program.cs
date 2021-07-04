using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace IfOrTernaryPerformance
{
	class Program
	{
		static void Main(string[] args)
		{
			var summary = BenchmarkRunner.Run<CustomBenchmark>();
			Console.ReadLine();
		}
	}

	[SimpleJob(RuntimeMoniker.Net50)]
	public class CustomBenchmark
	{
		private const bool _testBoolCondition = true;
		private List<TestObject> _testList;

		[Params(1_000, 10_000, 100_000, 1_000_000)]
		public int ListSizes;

		[IterationSetup]
		public void InitList()
		{
			this._testList = new List<TestObject>();
			for (int i = 0; i < ListSizes; i++)
			{
				this._testList.Add(new TestObject());
			}
		}

		[Benchmark]
		public void IfCondition()
		{
			foreach (var item in this._testList)
			{
				if (_testBoolCondition)
				{
					item.SimpleValue = 1;
					item.NormalValue = 2;
				}
				else
				{
					item.SimpleValue = -1;
					item.NormalValue = -2;
				}
			}
		}

		[Benchmark]
		public void TernaryCondition()
		{
			foreach (var item in this._testList)
			{
				item.SimpleValue = _testBoolCondition ? 1 : -1;
				item.NormalValue = _testBoolCondition ? 2 : -2;
			}
		}
	}

	public class TestObject
	{
		public int SimpleValue { get; set; }
		public int NormalValue { get; set; }
	}
}

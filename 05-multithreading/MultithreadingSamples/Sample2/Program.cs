using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample2
{
	class Program
	{
		static Stopwatch sw = new Stopwatch();

		static void Main(string[] args)
		{
			
			var tp = new MyThreadPool<long>(4);
			sw.Start();
			for(int i = 0; i < 1000; i++)
			{
				int i1 = i;
				tp.Add(CheckPrime, 15485867 + i1);
//				Task.Run(() => CheckPrime(15485867 + i1));
//				CheckPrime(15485867 + i1);
			}
			Console.ReadLine();
		}


		private static void CheckPrime(long n)
		{
			for(int i = 2; i <= n / 2; i++)
			{
				if(n % i == 0)
				{
					Console.WriteLine("{2}	FALSE: {0} is complex, found divisor {1}", n, i, sw.ElapsedMilliseconds);
					return;
				}
			}
			Console.WriteLine("{1}	TRUE: {0} is prime", n, sw.ElapsedMilliseconds);
		}
	}
}

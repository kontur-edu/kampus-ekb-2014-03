using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace cleancode
{
	static class LinqSamples
	{
		public static void UseIEnumerable()
		{
			var array = new List<int> {2,3,5,7,11,13};
			foreach (var item in array)
				Console.WriteLine(item);

			// foreach — это сокращенная запись вот этого:
			var enumerator = array.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Console.WriteLine(enumerator.Current);
				}
			}
			finally
			{
				enumerator.Dispose();
			}
		}

		public static void UseYieldReturn()
		{
			foreach (var guid in AllGuids())
			{
				Console.WriteLine(guid);
			}
		}
		
		public static IEnumerable<string> AllGuids()
		{
			yield return Guid.Empty.ToString();
			while (true)
				yield return Guid.NewGuid().ToString();
		}

		public static void SelectManySample()
		{
			//разбиваем текст на слова
			string[] words = File.ReadLines("text.txt")
				.SelectMany(line => Regex.Split(line, @"\W+"))
				.Where(word => !string.IsNullOrEmpty(word))
				.Select(line => line.ToLower())
				.ToArray();
			foreach (var word in words)
				Console.WriteLine(word);
		}
	}
}

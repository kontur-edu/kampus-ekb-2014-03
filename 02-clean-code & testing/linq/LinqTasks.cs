using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace cleancode
{
	static class LinqTasks
	{

		public static void PrintPoints()
		{
			// Задача 1. Прочитать из файла points.txt список точек на плоскости
			IEnumerable<Point> points = null; //TOOD


			foreach (var point in points)
				Console.WriteLine(point);
		}


		public static void PrintLongestWordsForEachStartingChar()
		{
			// Задача2. Для каждой буквы найти самое длинное слово, начинающееся с этой буквы, содержащееся в файле text.txt.
		}

	}
}

using System;
using System.Collections.Generic;
using System.Linq;


namespace parse
{
    public static class Program
    {
	
		public static void Main(string[] args)
		{
			var parser = new Parser('"', '\'');
			foreach (var field in parser.SplitToFields(Console.ReadLine()))
			{
				Console.WriteLine(field);
			}
		}
    }

    public class Parser
    {
        private char[] quoteChars;

        public Parser(params char[] quoteChars)
        {
            this.quoteChars = quoteChars;
        }

        public string[] SplitToFields(string line)
        {
            var pos = 0;
            var res = new List<string>();
            while (pos < line.Length)
            {
                while (pos < line.Length && line[pos] == ' ')
                    pos++;
                if (pos < line.Length)
                {
                    var token = Pole(line, pos);
                    res.Add(token);
                    pos += token.Length;
                }
            }
            return res.ToArray();
        }

        public string Pole(string line, int i)
        {
            // Задание 1
            // 1. Переименуйте метод, назвав его правильно. Переименование: F2 или Ctrl+R+R
			// 2. Дайте аргументу i более правильное имя.
			// 3. Выделите в отдельные методы блоки кода, ответственные за чтение закавыченного и простого полей.
            // Выделение метода — Ctrl+R+M (VS hotkey) или Ctrl+Alt+M (Resharper hotkey)
			var pos = i;
			if (quoteChars.Contains(line[i]))
			{
				pos++;
                var q = line[i];
                while (pos < line.Length)
                {
                    if (line[pos] == q)
                        return line.Substring(i, pos - i + 1);
                    if (line[pos] == '\\')
                        pos++;
                    pos++;
                }
                return line.Substring(i);
            }
            else
            {
                while (pos < line.Length && line[pos] != ' ') pos++;
                return line.Substring(i, pos - i);
            }
        }
    }
}

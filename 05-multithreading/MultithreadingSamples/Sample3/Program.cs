using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sample3
{
	class Program
	{
		static void Main(string[] args)
		{
			var addr = IPAddress.Parse(args[0]);
			var port = int.Parse(args[1]);
			var url = string.Format("http://{0}:{1}/data/", addr, port);

			var sw = new Stopwatch();
			sw.Start();
			var tasks =new List<Task>();
			for(int i = 0; i < 300; i++)
			{
				tasks.Add(DoRequest(url + i));
			}
			Task.WaitAll(tasks.ToArray());
			Console.WriteLine(sw.ElapsedMilliseconds);
		}

		private async static Task DoRequest(string url)
		{
			var client = CreateWebRequest(url);
			using(var response = await client.GetResponseAsync())
			{
				var ms = new MemoryStream();
				response.GetResponseStream().CopyToAsync(ms);
				Console.WriteLine(Encoding.GetEncoding(1251).GetString(ms.ToArray()));
			}
		}


		private static HttpWebRequest CreateWebRequest(string url)
		{
			var webRequest = WebRequest.CreateHttp(url);
			webRequest.Method = WebRequestMethods.Http.Get;
			webRequest.ServicePoint.Expect100Continue = false;
			webRequest.ServicePoint.UseNagleAlgorithm = false;
			webRequest.ServicePoint.ConnectionLimit = 1024;
			webRequest.Proxy = null;
			webRequest.KeepAlive = true;
			webRequest.Timeout = 30000;
			return webRequest;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample3server
{
	class Program
	{
		private static HttpListener listener;

		static void Main(string[] args)
		{
			listener = new HttpListener();
			listener.Prefixes.Add("http://+:31337/data/");
			listener.Start();

			List<Timer> timers = new List<Timer>();

			while(true)
			{
				try
				{
					var context = listener.GetContext();
					Console.WriteLine("Accepted client {0}", context.Request.RemoteEndPoint);
					timers.Add(new Timer(state =>
					{
						var ctx = (HttpListenerContext) state;
						try
						{
							Console.WriteLine("Processing client {0}	{1}", context.Request.RemoteEndPoint, ctx.Request.RawUrl);
							var bytes = Encoding.GetEncoding(1251).GetBytes(ctx.Request.RawUrl);
							ctx.Response.OutputStream.Write(bytes, 0, bytes.Length);
							Console.WriteLine("Written to client {0}	{1}", context.Request.RemoteEndPoint, ctx.Request.RawUrl);
						}
						finally
						{
							ctx.Response.Close();
							Console.WriteLine("Processed client {0}	{1}", context.Request.RemoteEndPoint, ctx.Request.RawUrl);
						}
					}, context, 1000, Timeout.Infinite));
				}
				catch(Exception e)
				{
					Console.Error.WriteLine(e);
				}
			}
		}
	}
}

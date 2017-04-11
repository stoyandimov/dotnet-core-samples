using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;

namespace core.web
{
	class Program
	{
		static void Main(string[] args)
		{
			new WebHostBuilder()
				.UseKestrel()
				.UseStartup<Startup>()
				.UseUrls("http://localhost:8899")
				.Build()
				.Start();

			Console.WriteLine("Started on http://localhost:8899");

			Console.ReadLine();
		}
	}

	public class Startup
	{
		public void Configure(IApplicationBuilder app)
		{
			app.Run(c => c.Response.WriteAsync("Hi"));
		}
	}
}

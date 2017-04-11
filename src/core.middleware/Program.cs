using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

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
			app.UseH1Middleware(1);
			app.Run(c => c.Response.WriteAsync("Hi"));
		}
	}

	public static class H1MiddlewareExtension
	{
		public static void UseH1Middleware(this IApplicationBuilder app, int h)
		{
			app.UseMiddleware<H1Middleware>();
		}
	}

	public class H1Middleware
	{
		private readonly RequestDelegate _next;
		private readonly int _h;

		public H1Middleware(RequestDelegate next, int h)
		{
			_next = next;
			_h = h;
		}

		public async Task Invoke(HttpContext context)
		{
			await context.Response.WriteAsync($"<h{_h}>");
			await _next(context);
			await context.Response.WriteAsync($"</h{_h}>");
		}
	}
}

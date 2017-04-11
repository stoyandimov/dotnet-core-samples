using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace core.mvc
{
	class Program
	{
		static void Main(string[] args)
		{
			new WebHostBuilder()
				.UseStartup<Startup>()
				.UseKestrel()
				.UseUrls("http://localhost:9988")
				.Build()
				.Start();

			Console.WriteLine("Started on http://localhost:9988");
			Console.ReadLine();
		}
	}

	class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
		}
		public void Configure(IApplicationBuilder app)
		{
			app.UseMvcWithDefaultRoute();
		}
	}

	public class HomeController : Controller
	{
		public string Index()
		{
			return $"Hi from {nameof(HomeController)}.{nameof(Index)}";
		}
	}
}

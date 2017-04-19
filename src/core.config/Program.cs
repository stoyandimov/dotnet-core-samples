using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;

namespace core.config
{
	class Program
	{
		static void Main(string[] args)
		{
			var config = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile("appsettings.local.json", optional: false, reloadOnChange: true) // overrides
				//.AddEnvironmentVariables()
				.Build();

			Console.WriteLine($"App: {config["General:AppName"]}");
			Console.WriteLine($"Env: {config["General:Environment"]}");
		}
	}
}

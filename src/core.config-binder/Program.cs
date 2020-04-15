using System;
using Microsoft.Extensions.Configuration;

namespace ConfigBuilder
{
	class Program
	{
		static void Main(string[] args)
		{
			IConfigurationRoot cfg = new ConfigurationBuilder()
				.AddCommandLine(args)
				.Build();

			var config = cfg.Get<Config>();

			Console.WriteLine("Name's " + config?.Name);
		}
	}

	public class Config
	{
		public string Name { get; set; }
	}
}

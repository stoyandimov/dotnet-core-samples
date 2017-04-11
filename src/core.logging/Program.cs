using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;

namespace core.logging
{
	class Program
	{
		static void Main(string[] args)
		{
			// Create logger factory
			ILoggerFactory loggerFactory = new LoggerFactory();

			// Register logger
			loggerFactory.AddProvider(new ConsoleLoggerProvider((msg, level) => true, false));

			// Cerate logger
			ILogger logger = loggerFactory.CreateLogger(nameof(Main));

			logger.LogInformation("Starting...");
			logger.LogWarning("Warning");
			logger.LogError("Error");
			logger.LogCritical("Criticle");
			logger.LogDebug("Debug");
			logger.LogTrace("Trace");

			Console.ReadLine();
		}
	}
}

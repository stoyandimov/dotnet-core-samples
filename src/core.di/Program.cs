using Microsoft.Extensions.DependencyInjection;
using System;

namespace core.di
{
	class Program
	{
		static void Main(string[] args)
		{
			IServiceCollection services = new ServiceCollection();
			System.IServiceProvider di = services.AddTransient<Car>()
							 .AddTransient<Engine>(s => new Engine(5))
							 .BuildServiceProvider();

			Car car = di.GetService<Car>();
			// or 
			car = ActivatorUtilities.CreateInstance<Car>(di);

			System.Console.WriteLine(car.Engine.HorsePowers);
		}
	}

	public class Car
	{
		public Engine Engine { get; set; }

		public Car(Engine engine)
		{
			Engine = engine;
		}
	}

	public class Engine
	{
		public int HorsePowers { get; set; }

		public Engine(int hp)
		{
			HorsePowers = hp;
		}
	}
}

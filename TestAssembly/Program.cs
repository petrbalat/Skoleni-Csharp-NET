extern alias oldwinsor;

using System;
using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor.Installer;
using Castle.Windsor;

namespace TestAssembly
{
	class Program
	{
		public static void Main(string[] args)
		{
			Castle3();
			Castle2();
			
			Console.ReadKey(true);
		}
		
		static void Castle2()
		{
			var container2 = new oldwinsor::Castle.Windsor.WindsorContainer();
			container2.AddComponent<IDateTimeProvider, LocalDateTimeProvider>();
			var king = container2.Resolve<IDateTimeProvider>();
			Console.WriteLine(king.Now);
		}
		
		static void Castle3()
		{
			var container = new WindsorContainer();
			container.Install(FromAssembly.This());
			var king = container.Resolve<IDateTimeProvider>();
			Console.WriteLine(king.Now);
			container.Dispose();
		}
	}
	
	public interface IDateTimeProvider
	{
		DateTime Now {get;}
	}
	
	public class LocalDateTimeProvider : IDateTimeProvider
	{
		public DateTime Now {
			get {
				return DateTime.Now;//lokalni now jinak pouzivat DateTime.UtcNow coz asi pro ssp nema cenu
			}
		}
	}
	
	public class RepositoriesInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Classes.FromThisAssembly()
			                   .Where(global::Castle.MicroKernel.Registration.Component.IsInSameNamespaceAs<IDateTimeProvider>())
			                   .WithService.DefaultInterfaces().LifestyleSingleton());
		}
	}
}
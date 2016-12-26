using SimpleApp.Application;
using SimpleApp.Application.Interfaces;
using SimpleApp.Domain.Interfaces.Repository;
using SimpleApp.Domain.Interfaces.Services;
using SimpleApp.Domain.Services;
using SimpleApp.Infra.Data.Context;
using SimpleApp.Infra.Data.Repository;
using SimpleInjector;

namespace SimpleApp.Infra.CrossCutting.IoC
{
	public class BootStrapper
	{
		public static void RegisterServices(Container container)
		{
			// Lifestyle.Transient => Uma instancia para cada solicitacao.
			// Lifestyle.Singleton => Uma instancia unica para a classe.
			// Lifestyle.Scoped => Uma isntancia unica para o request.

			//App
			container.Register<ICategorieAppService, CategorieAppService>(Lifestyle.Scoped);

			//Domain
			container.Register<ICategorieService, CategorieService>(Lifestyle.Scoped);

			//Data
			container.Register<ICategorieRepository, CategorieRepository>(Lifestyle.Scoped);
			container.Register<BaseContext>(Lifestyle.Scoped);
		}
	}
}

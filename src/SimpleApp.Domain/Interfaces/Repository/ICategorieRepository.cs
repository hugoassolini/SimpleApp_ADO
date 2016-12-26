using SimpleApp.Domain.Entities;

namespace SimpleApp.Domain.Interfaces.Repository
{
	public interface ICategorieRepository : IRepository<Categorie>
	{
		Categorie FindByName(string name);
	}
}

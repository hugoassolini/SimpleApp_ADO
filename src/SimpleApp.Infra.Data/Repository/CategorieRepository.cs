using SimpleApp.Domain.Entities;
using SimpleApp.Domain.Interfaces.Repository;
using SimpleApp.Infra.Data.Context;
using System;
using System.Collections.Generic;

namespace SimpleApp.Infra.Data.Repository
{
	public class CategorieRepository : ICategorieRepository
	{
		private BaseContext dbContext;

		public CategorieRepository(BaseContext context)
		{
			this.dbContext = context;
		}

		public Categorie FindById(int id)
		{
			using (var command = dbContext._connection.CreateCommand())
			{
				command.CommandText = "select * from Categories where CategoryID = @id";

				var paramId = command.CreateParameter();
				paramId.ParameterName = "id";
				paramId.Value = id;

				command.Parameters.Add(paramId);

				dbContext._connection.Open();
				var dr = command.ExecuteReader();

				Categorie categorie = null;
				if (dr.Read())
				{
					categorie = new Categorie();
					categorie.CategoryID = Convert.ToInt32(dr["CategoryID"]);
					categorie.CategoryName = dr["CategoryName"].ToString();
					categorie.Description = dr["Description"].ToString();
				}

				return categorie;
			}
		}

		public Categorie FindByName(string name)
		{
			using (var command = dbContext._connection.CreateCommand())
			{
				command.CommandText = "select * from Categories where CategoryName = @name";

				var paramId = command.CreateParameter();
				paramId.ParameterName = "name";
				paramId.Value = name;

				command.Parameters.Add(paramId);

				dbContext._connection.Open();
				var dr = command.ExecuteReader();

				Categorie categorie = null;
				if (dr.Read())
				{
					categorie = new Categorie();
					categorie.CategoryID = Convert.ToInt32(dr["CategoryID"]);
					categorie.CategoryName = dr["CategoryName"].ToString();
					categorie.Description = dr["Description"].ToString();
				}

				return categorie;
			}
		}

		public List<Categorie> GetAll()
		{
			using (var command = dbContext._connection.CreateCommand())
			{
				command.CommandText = "select * from Categories";

				dbContext._connection.Open();
				var dr = command.ExecuteReader();

				List<Categorie> listCategorie = new List<Categorie>();
				Categorie categorie;
				while (dr.Read())
				{
					categorie = new Categorie();

					categorie.CategoryID = Convert.ToInt32(dr["CategoryID"]);
					categorie.CategoryName = dr["CategoryName"].ToString();
					categorie.Description = dr["description"].ToString();

					listCategorie.Add(categorie);
				}

				return listCategorie;
			}
		}

		public void Add(Categorie categorie)
		{
			using (var command = dbContext._connection.CreateCommand())
			{
				command.CommandText = "insert into Categories (CategoryName, Description) values (@name, @description)";

				var paramName = command.CreateParameter();
				paramName.ParameterName = "name";
				paramName.Value = categorie.CategoryName;

				var paramDescription = command.CreateParameter();
				paramDescription.ParameterName = "description";
				paramDescription.Value = categorie.Description;

				command.Parameters.Add(paramName);
				command.Parameters.Add(paramDescription);

				dbContext._connection.Open();
				command.ExecuteNonQuery();
			}
		}

		public void Delete(int id)
		{
			using (var command = dbContext._connection.CreateCommand())
			{
				command.CommandText = "delete from Categories where CategoryID = @id";

				var paramId = command.CreateParameter();
				paramId.ParameterName = "id";
				paramId.Value = id;

				command.Parameters.Add(paramId);

				dbContext._connection.Open();
				command.ExecuteNonQuery();
			}
		}

		public void Update(Categorie categorie)
		{
			using (var command = dbContext._connection.CreateCommand())
			{
				command.CommandText = "update Categories set CategoryName = @name, Description = @description where CategoryID = @id";

				var paramId = command.CreateParameter();
				paramId.ParameterName = "id";
				paramId.Value = categorie.CategoryID;

				var paramName = command.CreateParameter();
				paramName.ParameterName = "name";
				paramName.Value = categorie.CategoryName;

				var paramDescription = command.CreateParameter();
				paramDescription.ParameterName = "description";
				paramDescription.Value = categorie.Description;

				command.Parameters.Add(paramId);
				command.Parameters.Add(paramName);
				command.Parameters.Add(paramDescription);

				dbContext._connection.Open();
				command.ExecuteNonQuery();
			}
		}

		public void Dispose()
		{
			dbContext.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SimpleApp.Infra.Data.Context
{
	public class BaseContext : IDisposable
	{
		private readonly string connectionstring = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
		public IDbConnection _connection;

		public BaseContext()
		{
			_connection = new SqlConnection(connectionstring);
		}

		public void Dispose()
		{
			_connection.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}

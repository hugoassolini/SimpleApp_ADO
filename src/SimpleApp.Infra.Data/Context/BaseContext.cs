using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SimpleApp.Infra.Data.Context
{
	public class BaseContext : IDisposable
	{
		private readonly string connectionstring = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
		private IDbConnection _connection;
		private IDbCommand _command;

		public BaseContext()
		{

		}

		private IDbCommand DbCommand
		{
			get
			{
				if (_command == null)
				{
					_command = Connection.CreateCommand();
				}
				return _command;
			}
			set
			{
				_command = value;
			}
		}

		public IDbCommand CreateCommand()
		{
			return Connection.CreateCommand();
		}

		public IDbCommand CreateCommand(string value)
		{
			DbCommand.Parameters.Clear();
			DbCommand.CommandText = value;
			return DbCommand;
		}

		private IDbConnection Connection
		{
			get
			{
				if (_connection == null) _connection = new SqlConnection(connectionstring);
				return _connection;
			}
		}

		public void Open()
		{
			if (Connection.State == ConnectionState.Closed)
				Connection.Open();
		}

		public void Close()
		{
			if ((_connection != null) && (_connection.State == ConnectionState.Open))
				_connection.Close();
		}

		public void Dispose()
		{
			if (_connection != null) _connection.Dispose();
			if (_command != null) _command.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}

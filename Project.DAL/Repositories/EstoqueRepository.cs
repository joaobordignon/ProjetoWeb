using Project.DAL.Contracts;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace Project.DAL.Repositories
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly string connectionString;
        public EstoqueRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        }
        public void Delete(int id)
        {
            string query = "Delete from Estoque where IdEstoque = @IdEstoque";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, new { IdEstoque = id });
            }
        }

        public void Insert(Estoque obj)
        {
            string query = "insert into Estoque(Nome) values(@Nome)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public List<Estoque> SelectAll()
        {
            string query = "Select * From Estoque";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Estoque>(query).ToList();
            }
        }

        public Estoque SelectById(int id)
        {
            string query = "Select * From Estoque where IdEstoque = @IdEstoque";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.QuerySingleOrDefault<Estoque>(query, new {IdEstoque = id});
          
            }
        }

        public void Update(Estoque obj)
        {
            string query = "Update Estoque set Nome = @Nome where IdEstoque = @IdEstoque";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }
    }
}

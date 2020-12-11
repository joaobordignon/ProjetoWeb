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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public Estoque SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Estoque obj)
        {
            throw new NotImplementedException();
        }
    }
}

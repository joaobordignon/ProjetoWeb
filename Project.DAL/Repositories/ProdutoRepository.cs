using Dapper;
using Project.DAL.Contracts;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly string connectionString;
        public ProdutoRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;      
        }
        public void Delete(int id)
        {
            string query = "Delete from Produto where IdProduto = @IdProduto";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, new { IdEstoque = id });
            }
        }

        public void Insert(Produto obj)
        {
            string query = "insert into Produto(Nome, Preco, Quantidade, IdEstoque) values(@Nome, @Preco, @Quantidade, @IdEstoque)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public List<Produto> SelectAll()
        {
            string query = "Select * From Produto";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Produto>(query).ToList();
            }
        }

        public Produto SelectById(int id)
        {
            string query = "Select * From Produto where IdProduto = @IdProduto";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.QuerySingleOrDefault<Produto>(query, new { IdProduto = id });

            }
        }

        public void Update(Produto obj)
        {
            string query = "Update Produto set Nome = @Nome, Preco = @Preco, Quantidade = @Quantidade, IdEstoque = @IdEstoque Where IdProduto = @IdProduto";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public List<Produto> SelectByPriceRange(decimal precoMinimo, decimal precoMaximo)
        {
            string query = "Select * From Produto where Preco BETWEEN " + precoMinimo + " AND " + precoMaximo;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Produto>(query).ToList();
            }
        }
    }
}

using Project.DAL.Contracts;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            throw new NotImplementedException();
        }

        public void Insert(Produto obj)
        {
            throw new NotImplementedException();
        }

        public List<Produto> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Produto SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Produto obj)
        {
            throw new NotImplementedException();
        }

        public List<Produto> SelectByPriceRange(decimal precoMinimo, decimal precoMaximo)
        {
            throw new NotImplementedException();
        }
    }
}

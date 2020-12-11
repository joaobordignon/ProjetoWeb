using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Contracts
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
        List<Produto> SelectByPriceRange(decimal precoMinimo, decimal precoMaximo);
    }
}

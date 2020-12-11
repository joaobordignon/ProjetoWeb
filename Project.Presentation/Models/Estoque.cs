using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Presentation.Models
{
    public class Estoque
    {
        public int IdEstoque { get; set; }
        public string Nome { get; set; }
        //Relacionamento de Associação
        public List<Produto> Produtos { get; set; }


    }
}
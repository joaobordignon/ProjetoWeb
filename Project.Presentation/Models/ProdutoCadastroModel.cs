using Project.DAL.Entities;
using Project.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Presentation.Models
{
    public class ProdutoCadastroModel
    {
        
        [Required(ErrorMessage = "Campo nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo preço é obrigatório.")]
        public decimal Preco { get; set; }
        [Required(ErrorMessage = "Campo quantidade é obrigatório.")]
        public int Quantidade { get; set; }
        [Required(ErrorMessage = "Campo estoque é obrigatório.")]
        //[Display(Name ="Estoque")]
        public int IdEstoque { get; set; }
        public IEnumerable<SelectListItem> Estoques { get; set; }
    }

}
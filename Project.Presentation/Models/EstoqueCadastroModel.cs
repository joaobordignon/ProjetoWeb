using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Presentation.Models
{
    public class EstoqueCadastroModel
    {
        [Required(ErrorMessage = "Campo obrigatorio")]
        public string Nome { get; set; }
    }
}
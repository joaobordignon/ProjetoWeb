using Project.DAL.Entities;
using Project.DAL.Repositories;
using Project.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Presentation.Controllers
{
    public class ProdutoController : Controller
    {
        private IEnumerable<SelectListItem> GetRoles()
        {
            var estoqueDiponivelDB = new EstoqueRepository();
            var roles = estoqueDiponivelDB
                        .SelectAll()
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.IdEstoque.ToString(),
                                    Text = x.Nome
                                });

            return new SelectList(roles, "Value", "Text");
        }

        // GET: Produto
        public ActionResult Cadastro()
        {
            var model = new ProdutoCadastroModel
            {
                Estoques = GetRoles()
            };
            return View(model);
            
        }
        [HttpPost]
        public ActionResult Cadastro(ProdutoCadastroModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Produto produto = new Produto();
                    produto.Nome = model.Nome;
                    produto.Preco = model.Preco;
                    produto.Quantidade = model.Quantidade;
                    produto.IdEstoque = model.IdEstoque;
                    var repo = new EstoqueRepository();
                    var estoqueDropbox = repo.SelectAll();
                    

                    ProdutoRepository repository = new ProdutoRepository();
                    repository.Insert(produto);
                    
                    TempData["Mensagem"] = $"Produto {produto.Nome}, cadastrado com sucesso.";
                    ModelState.Clear();
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = e.Message;
                }
            }
            return View();
        }
    }
}
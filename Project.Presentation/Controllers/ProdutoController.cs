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
        // GET: Produto
        public ActionResult Cadastro()
        {
            
            return View();
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
                    model.Estoques = estoqueDropbox.ToList();
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
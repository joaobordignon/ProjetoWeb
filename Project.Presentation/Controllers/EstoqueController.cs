using AutoMapper;
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
    public class EstoqueController : Controller
    {
        // GET: Estoque
        public ActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastro(EstoqueCadastroModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Estoque estoque = Mapper.Map<Estoque>(model);
                    EstoqueRepository repository = new EstoqueRepository();
                    repository.Insert(estoque);
                    TempData["MensagemOk"] = $"Estoque {estoque.Nome}, cadastrado com sucesso.";
                    ModelState.Clear();
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = e.Message;

                }
            }
            return View();
        }

        public ActionResult Consulta()
        {
            List<EstoqueConsultaModel> model = new List<EstoqueConsultaModel>();
            try
            {
                EstoqueRepository repository = new EstoqueRepository();
                
                model = Mapper.Map<List<EstoqueConsultaModel>>(repository.SelectAll());

                
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }
            TempData["Mensagem"] = $"Quantidade de Registros: {model.Count}.";
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            
            try
            {
                EstoqueRepository repository = new EstoqueRepository();
                repository.Delete(id);
                
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }
            return View();
            
        }

        public ActionResult Update(int id)
        {
            EstoqueRepository repository = new EstoqueRepository();
            EstoqueUpdateModel model = new EstoqueUpdateModel();
                try
                {
                model = Mapper.Map<EstoqueUpdateModel>(repository.SelectById(id));
                

                
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = e.Message;
                }
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(int id, EstoqueUpdateModel model)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    Estoque estoque = new Estoque();
                    estoque.IdEstoque = id;
                    estoque.Nome = model.Nome;
                    EstoqueRepository repository = new EstoqueRepository();
                    repository.Update(estoque);
                    TempData["Mensagem"] = $"Estoque {estoque.Nome}, modificado com sucesso.";
                    ModelState.Clear();
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = e.Message;

                }
            }
            return View(model);
        }
    }
}
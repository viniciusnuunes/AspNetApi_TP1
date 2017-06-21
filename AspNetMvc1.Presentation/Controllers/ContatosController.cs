using System.Linq;
using System.Web.Mvc;
using AspNetMvc1.Data;
using AspNetMvc1.Presentation.Models;
using System.Collections.Generic;
using System;

namespace AspNetMvc1.Presentation.Controllers
{
    public class ContatosController : Controller
    {

        ContatosRepository repo = new ContatosRepository();

        // GET: Contatos
        public ActionResult ListOne()
        {
            return View(getViewModelsToReturn());
        }


        [HttpPost]
        public ActionResult ListOne(List<ContatoViewModel> models)
        {
            Session["contatosSession"] = models; 

            return RedirectToAction("ListTwo");
        }
        

        // GET: Contatos
        public ActionResult ListTwo()
        {
            return View(getViewModelsToReturn());
        }

        [HttpPost]
        public ActionResult ListTwo(IEnumerable<ContatoViewModel> models)
        {
            Session["contatosSession"] = models; 

            return RedirectToAction("ListOne");
        }


        public IEnumerable<ContatoViewModel> getViewModelsToReturn()
        {
            var contatos = repo.pegarContatos();
            List<ContatoViewModel> listaContatos = new List<ContatoViewModel>();

            if (Session["contatosSession"] != null)
            {
                listaContatos = (List<ContatoViewModel>)Session["contatosSession"];
            }
            else
            {
                return (contatos.Select(a => new ContatoViewModel()
                {
                    Id = a.Id,
                    nome = a.nome,
                    sobreNome = a.sobreNome,
                    telefone = a.telefone,
                    email = a.email,
                    isSelected = false
                })).ToList();
            }

            return (listaContatos);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class PessoaController : Controller
    {

        private PessoaDao pessoaDao = new PessoaDao();

        public ActionResult Details()
        {
            ViewBag.Controller = "Pessoa";
            ViewBag.Action = "PessoaDetails";
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Controller = "Pessoa";
            ViewBag.Action = "ActionCadastro";
            return View();
        }

        public ActionResult LisPessoas()
        {
            ViewBag.Controller = "Pessoa";
            ViewBag.Action = "ListaPessoas";
            var result = pessoaDao.ConsultaPessoa();
            return View(result);
        }


    }
}
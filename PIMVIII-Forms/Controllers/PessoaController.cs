using Microsoft.EntityFrameworkCore;
using PIM_VIII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIMVIII_Forms.Controllers
{
    public class PessoaController : Controller
    {
        
        private readonly DbContext _context;
        private readonly List<Pessoa> _listaPessoa = new List<Pessoa>(); 
        public PessoaController(DbContext context, List<Pessoa> listaPessoa)
        {
            _context = context;
            _listaPessoa = listaPessoa;
        }

        // GET: Pessoa
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IList<Pessoa> ConsultaPessoas()
        {
            return _listaPessoa;
        }
    }
}
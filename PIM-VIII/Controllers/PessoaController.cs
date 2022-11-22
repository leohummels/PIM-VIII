using Microsoft.AspNetCore.Mvc;
using PIM_VIII.Models;
using PIM_VIII.Models.DTO;
using PIM_VIII.Models.PessoaDao.PessoaDao;

namespace PIM_VIII.Controllers
{
    [ApiController]
    [Route("pessoa")]
    
    public class PessoaController : Controller
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();
        public IPessoaDao _pessoaDao { get; set; }

        public PessoaController(IPessoaDao pessoaDao)
        {
            _pessoaDao = pessoaDao;
        }
        
        public IActionResult Index()
        {
            return View(_pessoaDao.ConsulteTodos());
        }

        
        [HttpGet("AdicionaPessoa")]
        public IActionResult AdicionaPessoa()
        {
            return View();
        }

        [HttpGet("ConsultaPessoa")]
        public IActionResult ConsultaPessoa()
        {
            return View();
        }

        [HttpGet("PessoaEncontrada")]
        public IActionResult PessoaEncontrada(ConsultaPessoaDTO consulta)
        {
            Pessoa? pessoa = _pessoaDao.Consulte(consulta.Nome);
            return View(pessoa);
        }


        [HttpPost("AdicionaPessoa")]
        public IActionResult AdicionaPessoa([FromForm]PessoaDTO Pessoa)
        {
            Pessoa pessoaDTO = new Pessoa { Nome = Pessoa.Nome,};
            bool inseriu = _pessoaDao.Insira(Pessoa);
            if (inseriu)
            {
                return RedirectToAction("Index");
            }else
            {
                return StatusCode(500);
            }
                
        }


        [HttpPost("ConsultaPessoa")]
        public IActionResult ConsultaPessoa([FromForm]ConsultaPessoaDTO Pessoa)
        {    
            return RedirectToAction("PessoaEncontrada", Pessoa);
        }

        [HttpGet("All")]
        public IActionResult ConsultaPessoas()
        {
            var listaPessoas = _pessoaDao.ConsulteTodos();
            return Ok(listaPessoas);
        }

        [HttpPut]
        public void AlterePessoa(Pessoa Pessoa)
        {
            var pessoa = pessoas.FirstOrDefault(x => x.Nome == Pessoa.Nome);
            if(pessoa == null){ return; }
            pessoas.Add(pessoa);
        }

        [HttpDelete]
        public void ExcluaPessoa(Pessoa Pessoa)
        {
            var pessoa = pessoas.FirstOrDefault(x => x.Nome == Pessoa.Nome);
            if (pessoa == null) { return; }
            pessoas.Remove(pessoa);

        }
    }
}

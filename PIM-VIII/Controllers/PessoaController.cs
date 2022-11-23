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

        [Route("Edit/{id}")]
        public IActionResult EditPessoa(int id)
        {
            var pessoa = _pessoaDao.Consulte(id);
            var PessoaDTO = new PessoaDTO{
                                        Nome = pessoa.Nome,
                                        Cpf = pessoa.Cpf,
                                        Cidade = pessoa.Endereco.Cidade,
                                        Logradouro = pessoa.Endereco.Logradouro,
                                        NumeroEndereco = pessoa.Endereco.Numero,
                                        Bairro = pessoa.Endereco.Bairro,
                                        DDD = pessoa.Telefone.DDD,
                                        Numero = pessoa.Telefone.Numero
                                    };
            return View(PessoaDTO);
        }

        [HttpPost("Edit/{Id}")]
        public IActionResult EditPessoa([FromForm]PessoaDTO pessoaDTO, int id)
        {
            var pessoa = _pessoaDao.Aletere(pessoaDTO,id);
            return RedirectToAction("Index");
        }
        
        [HttpGet("AdicionaPessoa")]
        public IActionResult AdicionaPessoa()
        {
            return View();
        }

        [HttpPost("AdicionaPessoa")]
        public IActionResult AdicionaPessoa([FromForm] PessoaDTO Pessoa)
        {
            Pessoa pessoaDTO = new Pessoa { Nome = Pessoa.Nome, };
            bool inseriu = _pessoaDao.Insira(Pessoa);
            if (inseriu)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return StatusCode(500);
            }

        }

        [Route("Details/{id}")]
        public IActionResult ConsultaPessoa(int id)
        {
            var pessoa = _pessoaDao.Consulte(id);
            return View(pessoa);
        }

        [HttpGet("Details")]
        public IActionResult PessoaEncontrada(Pessoa consulta)
        {
            Pessoa? pessoa = _pessoaDao.Consulte(consulta.Id);
            return View();
        }


        [HttpPost("ConsultaPessoa")]
        public IActionResult ConsultaPessoa([FromForm]ConsultaPessoaDTO Pessoa)
        {    
            return RedirectToAction("PessoaEncontrada", "Details/{id}", Pessoa);
        }

        [HttpGet("All")]
        public IActionResult ConsultaPessoas()
        {
            var listaPessoas = _pessoaDao.ConsulteTodos();
            return Ok(listaPessoas);
        }

        [Route("Delete/{id}")]
        public IActionResult ExcluaPessoa(int id)
        {
            _pessoaDao.Exclua(id);
            return RedirectToAction("Index");

        }
    }
}

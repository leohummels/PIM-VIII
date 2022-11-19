using Microsoft.AspNetCore.Mvc;
using PIM_VIII.DB;
using PIM_VIII.Models;
using PIM_VIII.Models.DTO;
using PIM_VIII.Models.PessoaDao.PessoaDao;
using System.Linq;
using System.Text.Json;

namespace PIM_VIII.Controllers
{
    [ApiController]
    [Route("pessoa")]
    
    public class PessoaController : ControllerBase
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();
        public IPessoaDao _pessoaDao { get; set; }

        public PessoaController(IPessoaDao pessoaDao)
        {
            _pessoaDao = pessoaDao;
        }

        [HttpPost("Add")]
        public IActionResult AdicionaPessoa(PessoaDTO Pessoa)
        {
            bool inseriu = _pessoaDao.Insira(Pessoa);
            if (inseriu)
            {
                return CreatedAtAction(nameof(ConsultaPessoa), new { Nome = Pessoa.Pessoa.Nome }, Pessoa);
            }else
            {
                return StatusCode(500);
            }
                
        }


        [HttpGet("{Nome}")]
        public IActionResult ConsultaPessoa(string Nome)
        {
            Pessoa? pessoa = pessoas.FirstOrDefault(x => x.Nome == Nome);
            if (pessoa == null)
            {
                return NotFound($"{Nome} não encontrada.");
            }
            return Ok(pessoa);
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

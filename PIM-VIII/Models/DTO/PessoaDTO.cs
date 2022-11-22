using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PIM_VIII.Models.DTO
{
    public class PessoaDTO
    {
        //Pessoa
        public string Nome { get; set; }
        public int Cpf { get; set; }      
        // Endereco
        public string Logradouro { get; set; }
        public int NumeroEndereco { get; set; }
        public int Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        //Telefone
        public int Numero { get; set; }
        public int DDD { get; set; }
        //TipoTelefone
        public string Tipo { get; set; }
    }
}

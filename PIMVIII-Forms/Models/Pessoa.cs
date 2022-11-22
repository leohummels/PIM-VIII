using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIM_VIII.Models
{
    public class Pessoa
    {
        public int Id { get; set; }    
        public string Nome { get; set; }
        public int Cpf { get; set; }
        public Endereco Endereco { get; set; }
        public Telefone Telefone { get; set; }
    }
}

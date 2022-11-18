using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIM_VIII.Models
{
    public class Pessoa
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "CPF é um campo obrigatório")]
        public int Cpf { get; set; }

        [ForeignKey("endereco")]
        public Endereco Endereco { get; set; }

        [NotMapped]
        public Telefone Telefone { get; set; }
    }
}

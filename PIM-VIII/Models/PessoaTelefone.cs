
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIM_VIII.Models
{
    public class PessoaTelefone
    {
        [Key]
        public int IdPessoa { get; set; }
        [ForeignKey("ID_TELEFONE")]
        public int IdTelefone { get; set;}
    }
}

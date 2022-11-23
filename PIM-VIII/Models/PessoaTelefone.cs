
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIM_VIII.Models
{
    public class PessoaTelefone
    {
        [Key]
        public int Id { get; set; }
        public int Id_Pessoa { get; set; }
        public int Id_Telefone { get; set;}
    }
}

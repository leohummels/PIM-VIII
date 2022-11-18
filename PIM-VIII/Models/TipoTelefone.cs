using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIM_VIII.Models
{
    public class TipoTelefone
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Tipo { get; set; }
    }
}

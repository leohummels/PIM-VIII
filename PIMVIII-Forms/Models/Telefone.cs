using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIM_VIII.Models
{
    public class Telefone
    {
        [Key]
        public int Id { get; set; }
        public int Numero { get; set; }
        public int DDD { get; set; }
        [ForeignKey("tipo")]
        public TipoTelefone TipoTelefone { get; set; }
    }
}

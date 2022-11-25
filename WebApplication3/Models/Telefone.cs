using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
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
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class TipoTelefone
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Tipo { get; set; }
    }
}
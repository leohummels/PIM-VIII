﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PIM_VIII.Models.DTO
{
    public class PessoaDTO
    {
        public Pessoa Pessoa { get; set; }

        public Telefone Telefone { get; set; }

        public Endereco Endereco { get; set; }
    }
}

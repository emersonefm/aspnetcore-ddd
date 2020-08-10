﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informa o Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informa a Senha")]
        public string Senha { get; set; }
    }
}
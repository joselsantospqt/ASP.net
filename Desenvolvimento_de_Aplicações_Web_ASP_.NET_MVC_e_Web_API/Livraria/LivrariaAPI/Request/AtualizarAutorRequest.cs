﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaAPI.Request
{
    public class AtualizarAutorRequest
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Datanascimento { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaAPI.Request
{
    public class CriarAutorRequest
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Datanascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}

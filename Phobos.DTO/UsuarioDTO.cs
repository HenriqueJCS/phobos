using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phobos.DTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string SenhaUsuario { get; set; }
        public DateTime DataNacimentoUsuario { get; set; }
        public int UsuarioTP { get; set; }
    }
}

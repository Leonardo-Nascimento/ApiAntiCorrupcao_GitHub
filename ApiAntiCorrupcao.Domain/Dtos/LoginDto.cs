using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAntiCorrupcao.Domain.Dtos
{
    public class LoginDto
    {
        public LoginDto()
        {
        }
        public string userName { get; set; }
        public string Senha { get; set; }
        public string? Token { get; set; } = null;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login1.Models.Entidades
{
    public class PasswordReset
    {
        public string Number { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int Codigo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login1.Models
{
    public class ResponseLogin : ResponseBase
    {
        public string name { get; set; }

        public char? typeU { get; set; }

        public string email { get; set; }

        public string numberr { get; set; }
    }
}

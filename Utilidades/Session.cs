using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login1.Models;

namespace Login1.Utilidades
{
    public class Session
    {
        public static string? name {  get; set; }
        public static char? typeU { get; set; }

        public static string email { get; set; }

        public static string number { get; set; }

        public static string imageUrl { get; set; }
        //public void Logout()
        //{
        //    name = null;
        //    typeU = ' ';
        //}
    }
}

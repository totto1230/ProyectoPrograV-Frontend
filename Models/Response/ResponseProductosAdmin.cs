﻿using Login1.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login1.Models.Response
{
    public class ResponseProductosAdmin : ResponseBase
    {
        public ProductosAdmin productos { get; set; }
    }
}

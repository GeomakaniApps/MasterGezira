﻿using DataLayer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Reference : Entity
    {
        public int id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
    }
}
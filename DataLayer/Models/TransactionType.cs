﻿using DataLayer.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class TransactionType:Entity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
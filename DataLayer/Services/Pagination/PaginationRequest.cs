﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services.Pagination
{
    public class PaginationRequest<T>
    {
        public T? Data { get; set; }
        public int Count { get; set; }
    }
}
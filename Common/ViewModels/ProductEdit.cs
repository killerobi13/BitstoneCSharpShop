﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class ProductEdit
    {
        public Product Product { get; set; }
        
        public IEnumerable<Category> Categories { get; set; }
    }
}

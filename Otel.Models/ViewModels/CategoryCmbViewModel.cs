﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.Models.ViewModels
{
    public class CategoryCmbViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int TotalSubCategory { get; set; }

        public override string ToString() => $"{Name} [{TotalSubCategory}]";
        
    }
}

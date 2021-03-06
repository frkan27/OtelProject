﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.Models.ViewModels
{
  public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; } = true;
        public override string ToString() => $"{Name} - {Price:c2} {(IsActive? "+":"x")}";
        //ısactive true ise + değilse x yaz.
       

    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace taaask10.model
{
    internal class Product
    {
        [Key]
        public int product { get; set; }

        [MaxLength(50)]
        [Unicode]
        public string name { get; set; }
        
        public int quantity{ get; set; }
        public decimal price { get; set; }
        public int sales { get; set; }
    }
}

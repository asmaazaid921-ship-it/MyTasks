using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace taaask10.model
{
    internal class Store
    {
        [MaxLength(50)]
        [Unicode]
        public string name { get; set; }
        [Key]

        public int storeid { get; set; }
        
        public int sales { get; set; }
    }
}

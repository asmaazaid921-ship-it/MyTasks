using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace taaask10.model
{
    internal class Customers
    {
        [Key]
        public int customerid { get; set; }

        [MaxLength (80)]
        [Unicode (false)]
        public string name { get; set; }
        [MaxLength(80)]
        [Unicode(false)]
        public int email { get; set; }
        public string criditcard { get; set; }
        public int sales { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace taaask10.model
{
    internal class Sales
    {
        [Key]
        public int salesid { get; set; }
        public DateTime date { get; set; }


        public int productid { get; set; }
        [ForeignKey("productid")]
        public Product product { get; set; }
        public int customerid { get; set; }
        [ForeignKey("customeri")]
        public Customers Customers { get; set; }

        public int storeid { get; set; }
        [ForeignKey("storeid")]
        public Store Store { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;

namespace Store.Models
{
    [PrimaryKey(nameof(ProductId), nameof(Color))]
    public class ProductColor
    {
        public int ProductId { get; set; }

        public Product Product { get; set; } = default!;

        public string Color { get; set; } = string.Empty;
    }
}

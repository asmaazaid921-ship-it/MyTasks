namespace Store.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string MainImg { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int Rate { get; set; }

        public bool Status { get; set; }

        public decimal Discount { get; set; }

        // Foreign Key for Category
        public int CategoryId { get; set; }

        // Navigation Property
        public Category? Category { get; set; }

        // Foreign Key for Brand
        public int BrandId { get; set; }
    }
}

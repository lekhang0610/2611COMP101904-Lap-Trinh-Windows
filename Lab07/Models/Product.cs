namespace ShopManagerMini.Models
{
    /// <summary>
    /// Lớp đại diện cho sản phẩm trong cửa hàng
    /// </summary>
    public class Product
    {
        public string ProductId { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public Product() { }

        public Product(string productId, string productName, string category, decimal unitPrice, int quantity)
        {
            ProductId = productId;
            ProductName = productName;
            Category = category;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }
    }
}

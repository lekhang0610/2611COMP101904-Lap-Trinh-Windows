namespace ProductManager;

public class Product : IEntity
{
    public string MaSP { get; }
    public string TenSP { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public string Id => MaSP;

    public Product(string maSP, string tenSP, decimal price, int quantity)
    {
        if (string.IsNullOrWhiteSpace(maSP))
            throw new ArgumentException("Ma san pham khong duoc rong.");
        if (price < 0)
            throw new ArgumentException("Don gia khong duoc am.");
        if (quantity < 0)
            throw new ArgumentException("So luong khong duoc am.");

        MaSP = maSP.Trim();
        TenSP = tenSP;
        Price = price;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"{MaSP,-10} {TenSP,-20} {Price,15:N0} {Quantity,10}";
    }
}

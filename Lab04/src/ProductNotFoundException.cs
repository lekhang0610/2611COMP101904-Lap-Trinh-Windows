namespace ProductManager;

public class ProductNotFoundException : Exception
{
    public ProductNotFoundException(string maSP)
        : base($"Khong tim thay san pham co ma '{maSP}'.")
    {
    }
}

namespace ProductManager;

public class DuplicateProductException : Exception
{
    public DuplicateProductException(string maSP)
        : base($"San pham co ma '{maSP}' da ton tai.")
    {
    }
}

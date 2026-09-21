namespace ProductManager;

public class ProductService
{
    private readonly Repository<Product> repository = new();

    public event Action<Product>? ProductAdded;
    public event Action<Product>? ProductRemoved;

    public void AddProduct(string maSP, string tenSP, decimal price, int quantity)
    {
        var product = new Product(maSP, tenSP, price, quantity);
        repository.Add(product);
        ProductAdded?.Invoke(product);
    }

    public void RemoveProduct(string maSP)
    {
        var product = repository.FindById(maSP);
        repository.Remove(maSP);
        if (product != null)
            ProductRemoved?.Invoke(product);
    }

    public Product FindById(string maSP)
    {
        var product = repository.FindById(maSP);
        if (product == null)
            throw new ProductNotFoundException(maSP);

        return product;
    }

    public List<Product> Search(string keyword)
    {
        Func<Product, bool> containsKeyword = p =>
            p.TenSP.Contains(keyword, StringComparison.OrdinalIgnoreCase);

        return repository.Find(containsKeyword);
    }

    public List<Product> Filter(decimal minPrice, decimal maxPrice)
    {
        Func<Product, bool> inRange = p => p.Price >= minPrice && p.Price <= maxPrice;
        return repository.Find(inRange);
    }

    public List<Product> GetAll()
    {
        return repository.GetAll();
    }

    public decimal GetTotalValue()
    {
        return repository.GetAll().Sum(p => p.Price * p.Quantity);
    }
}

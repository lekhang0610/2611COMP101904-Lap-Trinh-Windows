namespace ProductManager;

public class Repository<T> where T : IEntity
{
    private readonly List<T> items = new();

    public void Add(T item)
    {
        if (items.Any(x => x.Id == item.Id))
            throw new DuplicateProductException(item.Id);

        items.Add(item);
    }

    public void Remove(string id)
    {
        var item = FindById(id);
        if (item == null)
            throw new ProductNotFoundException(id);

        items.Remove(item);
    }

    public T? FindById(string id)
    {
        return items.FirstOrDefault(x => x.Id == id);
    }

    public List<T> Find(Func<T, bool> predicate)
    {
        return items.Where(predicate).ToList();
    }

    public List<T> GetAll()
    {
        return items.ToList();
    }
}

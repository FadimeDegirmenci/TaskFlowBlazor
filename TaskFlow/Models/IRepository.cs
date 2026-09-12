namespace TaskFlow.Models;

public interface IRepository<T> where T : class
{
    void Add(T item);
    List<T> GetAll();
}

public class InMemoryRepository<T> : IRepository<T> where T : class
{
    private readonly List<T> _items = new();

    public void Add(T item) => _items.Add(item);
    public List<T> GetAll() => _items;
}
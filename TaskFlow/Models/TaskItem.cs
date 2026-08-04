namespace TaskFlow.Models;

public class TaskItem
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public TaskPriority Priority { get; set; } = TaskPriority.Medium;

    public DateTime DueDate { get; set; }

    public bool IsCompleted { get; set; }

    // Constructor (parametresiz) - varsayılan değerlerle boş bir görev oluşturur
    public TaskItem()
    {
        DueDate = DateTime.Now.AddDays(1);
    }

    // Constructor (parametreli) - başlık ve öncelik zorunlu olarak verilerek oluşturulur
    public TaskItem(string title, TaskPriority priority)
    {
        Title = title;
        Priority = priority;
        DueDate = DateTime.Now.AddDays(1);
    }

    // virtual: alt sınıflar bu metodu "override" ederek kendi versiyonunu yazabilir
    public virtual string GetSummary()
    {
        return $"{Title} [{Priority}]";
    }
}
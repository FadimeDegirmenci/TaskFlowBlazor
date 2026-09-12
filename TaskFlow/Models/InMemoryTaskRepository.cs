namespace TaskFlow.Models;

public class InMemoryTaskRepository : ITaskRepository
{
    private readonly List<TaskItem> _tasks = new();

    public event Action<TaskItem>? TaskCompleted;

    public InMemoryTaskRepository()
    {
        _tasks.Add(new PersonalTask("Spor salonuna git", TaskPriority.Low) { Location = "Fitness Center", DueDate = DateTime.Now.AddDays(1) });
        _tasks.Add(new TeamTask("Sunum hazırla", TaskPriority.Critical, "Fadime") { DueDate = DateTime.Now.AddDays(-1) });
        _tasks.Add(new TeamTask("Kod incelemesi yap", TaskPriority.High, "Mehmet Hoca") { DueDate = DateTime.Now.AddDays(3) });
        _tasks.Add(new PersonalTask("Kitap oku", TaskPriority.Medium) { DueDate = DateTime.Now.AddDays(7), IsCompleted = true });
    }

    public List<TaskItem> GetAll()
    {
        return _tasks;
    }

    public void Add(TaskItem task)
    {
        _tasks.Add(task);
    }

    public void CompleteTask(Guid id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task is not null)
        {
            task.IsCompleted = true;
            TaskCompleted?.Invoke(task);
        }
    }

    public async Task<TaskItem?> GetByIdAsync(Guid id)
    {
        await Task.Delay(200);
        return _tasks.FirstOrDefault(t => t.Id == id);
    }
}
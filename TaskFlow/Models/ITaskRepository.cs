namespace TaskFlow.Models;

public interface ITaskRepository
{
    List<TaskItem> GetAll();
    void Add(TaskItem task);
    void CompleteTask(Guid id);
    event Action<TaskItem>? TaskCompleted;
    Task<TaskItem?> GetByIdAsync(Guid id);
}
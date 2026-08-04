namespace TaskFlow.Models;

public interface ITaskRepository
{
    List<TaskItem> GetAll();
    void Add(TaskItem task);
    void CompleteTask(Guid id);
}
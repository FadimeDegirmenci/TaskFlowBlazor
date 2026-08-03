namespace TaskFlow.Models;

public class PersonalTask : TaskItem
{
    public string? Location { get; set; }

    public PersonalTask(string title, TaskPriority priority) : base(title, priority)
    {
    }

    public override string GetSummary()
    {
        var baseSummary = base.GetSummary();
        return Location is null
            ? $"{baseSummary} (Kişisel)"
            : $"{baseSummary} (Kişisel - {Location})";
    }
}
namespace TaskFlow.Models;

public class TeamTask : TaskItem
{
    public string AssignedTo { get; set; } = string.Empty;

    public TeamTask(string title, TaskPriority priority, string assignedTo) : base(title, priority)
    {
        AssignedTo = assignedTo;
    }

    public override string GetSummary()
    {
        var baseSummary = base.GetSummary();
        return $"{baseSummary} (Takım - Sorumlu: {AssignedTo})";
    }
}
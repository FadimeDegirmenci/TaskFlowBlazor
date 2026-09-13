namespace TaskFlow.Models;

[AttributeUsage(AttributeTargets.Method)]
public class CommandAttribute : Attribute
{
    public string Name { get; }
    public CommandAttribute(string name) => Name = name;
}
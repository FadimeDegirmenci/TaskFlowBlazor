namespace TaskFlow.Models;

public class TaskLogger : IDisposable
{
    private readonly List<string> _logs = new();
    private bool _disposed;

    public void Log(string message)
    {
        _logs.Add($"{DateTime.Now:HH:mm:ss} - {message}");
    }

    public List<string> GetLogs() => _logs;

    public void Dispose()
    {
        _disposed = true;
        _logs.Add($"{DateTime.Now:HH:mm:ss} - TaskLogger kapatıldı, kaynaklar temizlendi.");
    }
}
namespace Middleware_Practice;

public interface IMessageWriter
{
    void Write(string message);
}

public class LoggingMessageWriter(ILogger<LoggingMessageWriter> logger) : IMessageWriter
{

    private readonly ILogger<LoggingMessageWriter> _logger = logger;

    public void Write(string message) =>
        _logger.LogInformation(message);
}
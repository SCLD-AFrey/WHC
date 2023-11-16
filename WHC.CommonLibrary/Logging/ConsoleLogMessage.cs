using Serilog.Events;

namespace WHC.CommonLibrary.Logging;

public class ConsoleLogMessage
{
    public LogEventLevel LogLevel { get; set; }
    public string? Text { get; set; }
}
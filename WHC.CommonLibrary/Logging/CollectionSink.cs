using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Display;

namespace WHC.CommonLibrary.Logging;

public class CollectionSink : ILogEventSink
{
    private readonly ITextFormatter m_textFormatter =
        new MessageTemplateTextFormatter("{Timestamp:HH:mm:ss} - {Message}{Exception}");

    public static List<ConsoleLogMessage> Events { get; set; } = new();

    public void Emit(LogEvent p_logEvent)
    {
        var renderer = new StringWriter();
        m_textFormatter.Format(p_logEvent, renderer);

        var message = new ConsoleLogMessage
        {
            Text = renderer.ToString(),
            LogLevel = p_logEvent.Level
        };

        Events.Insert(0, message);
    }

    public static void SetCollection(List<ConsoleLogMessage> p_sink)
    {
        Events = p_sink;
    }
}
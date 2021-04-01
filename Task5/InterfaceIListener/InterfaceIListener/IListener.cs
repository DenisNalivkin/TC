namespace InterfaceIListener
{
    /// <summary>
    /// Enum of types of events taking place.
    /// </summary>
    public enum LogLevel
    {
        Trace,
        Info,
        Warning,
        Error
    }
    /// <summary>
    /// Interface for listeners.
    /// </summary>
    public interface IListener
    {       
        string Source { get;  set; }
        LogLevel Loglevel { get; set; }
        void WriteMessage(string str, LogLevel InputlogLevel);
    }
}

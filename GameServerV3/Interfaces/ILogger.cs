namespace GameServerV3.Interfaces
{
    public interface ILogger
    {
        void InitializeLogger(RichTextBox logBox);
        void Log(string message);
    }
}
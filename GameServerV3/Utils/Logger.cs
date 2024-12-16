using GameServerV3.Interfaces;

namespace GameServerV3.Utils
{
    public class Logger : ILogger
    {
        private RichTextBox _logBox;

        public void InitializeLogger(RichTextBox logBox)
        {
            _logBox = logBox;
        }

        public void Log(string message)
        {
            if (_logBox == null)
            {
                Console.WriteLine(message);
            }
            else
            {
                _logBox.Invoke((MethodInvoker)delegate
                {
                    _logBox.AppendText($"{DateTime.Now}: {message}{Environment.NewLine}");
                });
            }
        }
    }
}
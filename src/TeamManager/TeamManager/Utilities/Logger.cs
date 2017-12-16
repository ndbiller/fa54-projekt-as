using System.Linq;
using System.Runtime.CompilerServices;
using log4net;

namespace TeamManager.Utilities
{
    /// <summary>
    /// The logger that we use is from apache:
    /// http://logging.apache.org/log4net/
    /// You can read the documentation there if you need to understand anything.
    /// Configuration you can find in App.config.
    /// </summary>
    public static class Logger
    {
        public static ILog GetLogger([CallerFilePath] string filename = "")
        {
            return LogManager.GetLogger(filename.Split('\\').Last());
        }
    }
}

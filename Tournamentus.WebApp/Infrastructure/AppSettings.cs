using Tournamentus.Core.Infrastructure;

namespace Tournamentus.WebApp.Infrastructure
{
    public class AppSettings
    {
        public AppSettings(ConnectionStringSettings connectionStrings)
        {
            ConnectionStrings = connectionStrings;
        }

        public ConnectionStringSettings ConnectionStrings { get; private set; }
    }
}

// Program.cs
using System;
using System.Windows.Forms;
using GameServerV3.Entities;
using GameServerV3.Interfaces;
using GameServerV3.Interfaces.Manager;
using GameServerV3.Utils;
using GameServerV3.Utils.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace GameServerV3
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(serviceProvider.GetRequiredService<GameServerForm>());
        }

        private static ServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ILogger, Logger>();
            services.AddSingleton<IGameState, GameState>();
            services.AddSingleton<IGameStateManager, GameStateManager>();
            services.AddSingleton<INetworkManager, NetworkManager>();
            services.AddTransient<IClientManager, ClientManager>();
            services.AddTransient<Func<IClientManager>>(provider =>
            {
                return () => provider.GetRequiredService<IClientManager>();
            });
            services.AddTransient<GameServerForm>();
            return services;
        }
    }
}

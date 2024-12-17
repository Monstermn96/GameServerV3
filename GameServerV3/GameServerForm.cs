// GameServerForm.cs
using GameServerV3.Interfaces;
using GameServerV3.Interfaces.Manager;
using System;
using System.Windows.Forms;

namespace GameServerV3
{
    public partial class GameServerForm : Form
    {
        private readonly INetworkManager networkManager;
        private readonly ILogger logger;

        public GameServerForm(ILogger logger, INetworkManager networkManager)
        {
            InitializeComponent();
            this.logger = logger;
            this.networkManager = networkManager;
            logger.InitializeLogger(ServerConsole);
            BindButtonEvents();
        }

        private void BindButtonEvents()
        {
            StartButton.Click += (s, e) => networkManager.StartServer();
            StopButton.Click += (s, e) => networkManager.StopServer();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            networkManager.StopServer();
        }
    }
}
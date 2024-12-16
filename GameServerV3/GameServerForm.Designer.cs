namespace GameServerV3
{
    partial class GameServerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ServerConsole = new RichTextBox();
            PlayerList = new ListBox();
            StartButton = new Button();
            StopButton = new Button();
            SuspendLayout();
            // 
            // ServerConsole
            // 
            ServerConsole.Location = new Point(12, 12);
            ServerConsole.Name = "ServerConsole";
            ServerConsole.Size = new Size(601, 514);
            ServerConsole.TabIndex = 0;
            ServerConsole.Text = "";
            // 
            // PlayerList
            // 
            PlayerList.FormattingEnabled = true;
            PlayerList.ItemHeight = 15;
            PlayerList.Location = new Point(619, 12);
            PlayerList.Name = "PlayerList";
            PlayerList.Size = new Size(276, 514);
            PlayerList.TabIndex = 1;
            // 
            // StartButton
            // 
            StartButton.Location = new Point(10, 593);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(89, 74);
            StartButton.TabIndex = 2;
            StartButton.Text = "Start Server";
            StartButton.UseVisualStyleBackColor = true;
            // 
            // StopButton
            // 
            StopButton.Location = new Point(105, 593);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(89, 74);
            StopButton.TabIndex = 3;
            StopButton.Text = "Stop Server";
            StopButton.UseVisualStyleBackColor = true;
            // 
            // GameServerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(907, 679);
            Controls.Add(StopButton);
            Controls.Add(StartButton);
            Controls.Add(PlayerList);
            Controls.Add(ServerConsole);
            Name = "GameServerForm";
            Text = "Game Server V3";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox ServerConsole;
        private ListBox PlayerList;
        private Button StartButton;
        private Button StopButton;
    }
}

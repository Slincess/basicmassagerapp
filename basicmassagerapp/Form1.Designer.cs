namespace basicmessagerapp
{
    partial class Form1
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
            messagelist = new FlowLayoutPanel();
            ServerConnectPanel = new FlowLayoutPanel();
            label3 = new Label();
            IPbox = new TextBox();
            PORTBOX = new TextBox();
            connectButton = new Button();
            ConnectionFeedback = new FlowLayoutPanel();
            label5 = new Label();
            ProfilePanel = new FlowLayoutPanel();
            label4 = new Label();
            NameBox = new TextBox();
            CloseProfile = new Button();
            textBox1 = new TextBox();
            CCUPANEL = new FlowLayoutPanel();
            label2 = new Label();
            servers = new FlowLayoutPanel();
            AddServer = new Button();
            label1 = new Label();
            NameText = new Label();
            ProfileEdit = new Button();
            panel1 = new Panel();
            ServerConnectPanel.SuspendLayout();
            ConnectionFeedback.SuspendLayout();
            ProfilePanel.SuspendLayout();
            servers.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // messagelist
            // 
            messagelist.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            messagelist.AutoScroll = true;
            messagelist.BackColor = Color.FromArgb(25, 26, 29);
            messagelist.BorderStyle = BorderStyle.FixedSingle;
            messagelist.FlowDirection = FlowDirection.TopDown;
            messagelist.Location = new Point(262, 12);
            messagelist.Name = "messagelist";
            messagelist.RightToLeft = RightToLeft.No;
            messagelist.Size = new Size(683, 562);
            messagelist.TabIndex = 9;
            messagelist.WrapContents = false;
            // 
            // ServerConnectPanel
            // 
            ServerConnectPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ServerConnectPanel.BackColor = Color.FromArgb(25, 26, 29);
            ServerConnectPanel.BorderStyle = BorderStyle.FixedSingle;
            ServerConnectPanel.Controls.Add(label3);
            ServerConnectPanel.Controls.Add(IPbox);
            ServerConnectPanel.Controls.Add(PORTBOX);
            ServerConnectPanel.Controls.Add(connectButton);
            ServerConnectPanel.Controls.Add(ConnectionFeedback);
            ServerConnectPanel.Location = new Point(12, 330);
            ServerConnectPanel.Name = "ServerConnectPanel";
            ServerConnectPanel.Size = new Size(223, 223);
            ServerConnectPanel.TabIndex = 16;
            ServerConnectPanel.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(30, 0);
            label3.Margin = new Padding(30, 0, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(165, 21);
            label3.TabIndex = 14;
            label3.Text = "Connect to new server";
            // 
            // IPbox
            // 
            IPbox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            IPbox.BackColor = Color.FromArgb(31, 32, 35);
            IPbox.BorderStyle = BorderStyle.FixedSingle;
            IPbox.ForeColor = SystemColors.Info;
            IPbox.Location = new Point(10, 36);
            IPbox.Margin = new Padding(10, 15, 3, 3);
            IPbox.Name = "IPbox";
            IPbox.PlaceholderText = "IP";
            IPbox.Size = new Size(195, 23);
            IPbox.TabIndex = 12;
            // 
            // PORTBOX
            // 
            PORTBOX.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            PORTBOX.BackColor = Color.FromArgb(31, 32, 35);
            PORTBOX.BorderStyle = BorderStyle.FixedSingle;
            PORTBOX.ForeColor = SystemColors.Info;
            PORTBOX.Location = new Point(10, 72);
            PORTBOX.Margin = new Padding(10, 10, 3, 3);
            PORTBOX.Name = "PORTBOX";
            PORTBOX.PlaceholderText = "port";
            PORTBOX.Size = new Size(195, 23);
            PORTBOX.TabIndex = 13;
            // 
            // connectButton
            // 
            connectButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            connectButton.BackColor = Color.FromArgb(64, 65, 68);
            connectButton.FlatAppearance.BorderSize = 0;
            connectButton.FlatStyle = FlatStyle.Flat;
            connectButton.ForeColor = SystemColors.Window;
            connectButton.Location = new Point(10, 101);
            connectButton.Margin = new Padding(10, 3, 3, 3);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(195, 26);
            connectButton.TabIndex = 6;
            connectButton.Text = "Connect";
            connectButton.UseVisualStyleBackColor = false;
            connectButton.Click += ConnectBtn_Click;
            // 
            // ConnectionFeedback
            // 
            ConnectionFeedback.AutoScroll = true;
            ConnectionFeedback.Controls.Add(label5);
            ConnectionFeedback.FlowDirection = FlowDirection.TopDown;
            ConnectionFeedback.Location = new Point(10, 133);
            ConnectionFeedback.Margin = new Padding(10, 3, 3, 3);
            ConnectionFeedback.Name = "ConnectionFeedback";
            ConnectionFeedback.Size = new Size(193, 80);
            ConnectionFeedback.TabIndex = 15;
            ConnectionFeedback.WrapContents = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(3, 3);
            label5.Margin = new Padding(3, 3, 3, 0);
            label5.Name = "label5";
            label5.Size = new Size(45, 19);
            label5.TabIndex = 0;
            label5.Text = "label5";
            // 
            // ProfilePanel
            // 
            ProfilePanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ProfilePanel.BackColor = Color.FromArgb(25, 26, 29);
            ProfilePanel.BorderStyle = BorderStyle.FixedSingle;
            ProfilePanel.Controls.Add(label4);
            ProfilePanel.Controls.Add(NameBox);
            ProfilePanel.Controls.Add(CloseProfile);
            ProfilePanel.Location = new Point(12, 461);
            ProfilePanel.Name = "ProfilePanel";
            ProfilePanel.Size = new Size(223, 91);
            ProfilePanel.TabIndex = 17;
            ProfilePanel.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(78, 0);
            label4.Margin = new Padding(78, 0, 3, 0);
            label4.Name = "label4";
            label4.Size = new Size(55, 21);
            label4.TabIndex = 14;
            label4.Text = "Profile";
            // 
            // NameBox
            // 
            NameBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            NameBox.BackColor = Color.FromArgb(31, 32, 35);
            NameBox.BorderStyle = BorderStyle.FixedSingle;
            NameBox.ForeColor = SystemColors.Info;
            NameBox.Location = new Point(10, 24);
            NameBox.Margin = new Padding(10, 3, 3, 3);
            NameBox.Name = "NameBox";
            NameBox.PlaceholderText = "Name";
            NameBox.Size = new Size(195, 23);
            NameBox.TabIndex = 7;
            NameBox.TextChanged += NameBox_TextChanged;
            // 
            // CloseProfile
            // 
            CloseProfile.BackColor = Color.FromArgb(64, 65, 68);
            CloseProfile.FlatAppearance.BorderSize = 0;
            CloseProfile.FlatStyle = FlatStyle.Flat;
            CloseProfile.ForeColor = SystemColors.ControlLight;
            CloseProfile.Location = new Point(10, 53);
            CloseProfile.Margin = new Padding(10, 3, 3, 3);
            CloseProfile.Name = "CloseProfile";
            CloseProfile.Size = new Size(195, 29);
            CloseProfile.TabIndex = 15;
            CloseProfile.Text = "Done and Close";
            CloseProfile.UseVisualStyleBackColor = false;
            CloseProfile.Click += CloseProfile_Click;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BackColor = Color.FromArgb(31, 32, 35);
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Segoe UI", 12F);
            textBox1.ForeColor = SystemColors.Info;
            textBox1.Location = new Point(262, 582);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "type your message";
            textBox1.Size = new Size(683, 29);
            textBox1.TabIndex = 0;
            textBox1.KeyDown += textBox1_Enter;
            // 
            // CCUPANEL
            // 
            CCUPANEL.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            CCUPANEL.AutoScroll = true;
            CCUPANEL.BackColor = Color.FromArgb(17, 17, 19);
            CCUPANEL.BorderStyle = BorderStyle.FixedSingle;
            CCUPANEL.FlowDirection = FlowDirection.TopDown;
            CCUPANEL.Location = new Point(75, 47);
            CCUPANEL.Name = "CCUPANEL";
            CCUPANEL.Padding = new Padding(10);
            CCUPANEL.Size = new Size(181, 495);
            CCUPANEL.TabIndex = 10;
            CCUPANEL.WrapContents = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(0, 0, 0, 0);
            label2.Font = new Font("Segoe UI", 15F);
            label2.ForeColor = SystemColors.Window;
            label2.Location = new Point(96, 12);
            label2.Name = "label2";
            label2.Size = new Size(121, 28);
            label2.TabIndex = 11;
            label2.Text = "Online Users";
            // 
            // servers
            // 
            servers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            servers.AutoScroll = true;
            servers.BorderStyle = BorderStyle.FixedSingle;
            servers.Controls.Add(AddServer);
            servers.FlowDirection = FlowDirection.TopDown;
            servers.Location = new Point(3, 47);
            servers.Name = "servers";
            servers.Size = new Size(66, 495);
            servers.TabIndex = 14;
            // 
            // AddServer
            // 
            AddServer.BackColor = Color.FromArgb(64, 65, 68);
            AddServer.FlatAppearance.BorderSize = 0;
            AddServer.FlatStyle = FlatStyle.Flat;
            AddServer.Font = new Font("Segoe UI", 11F);
            AddServer.ForeColor = SystemColors.Control;
            AddServer.Location = new Point(3, 3);
            AddServer.Name = "AddServer";
            AddServer.Size = new Size(54, 36);
            AddServer.TabIndex = 0;
            AddServer.Text = "add";
            AddServer.UseVisualStyleBackColor = false;
            AddServer.Click += AddServer_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(0, 0, 0, 0);
            label1.Font = new Font("Segoe UI", 15F);
            label1.ForeColor = SystemColors.Window;
            label1.Location = new Point(3, 12);
            label1.Name = "label1";
            label1.Size = new Size(72, 28);
            label1.TabIndex = 15;
            label1.Text = "servers";
            // 
            // NameText
            // 
            NameText.Anchor = AnchorStyles.Left;
            NameText.AutoSize = true;
            NameText.Font = new Font("Segoe UI", 13F);
            NameText.ForeColor = SystemColors.Control;
            NameText.Location = new Point(0, 9);
            NameText.Margin = new Padding(10, 10, 3, 0);
            NameText.MaximumSize = new Size(156, 25);
            NameText.Name = "NameText";
            NameText.Size = new Size(156, 25);
            NameText.TabIndex = 0;
            NameText.Text = "blahhhhhhhhhhhh";
            // 
            // ProfileEdit
            // 
            ProfileEdit.Anchor = AnchorStyles.Right;
            ProfileEdit.BackColor = Color.FromArgb(64, 65, 68);
            ProfileEdit.FlatAppearance.BorderSize = 0;
            ProfileEdit.FlatStyle = FlatStyle.Flat;
            ProfileEdit.ForeColor = SystemColors.Control;
            ProfileEdit.Location = new Point(167, 9);
            ProfileEdit.Margin = new Padding(180, 0, 3, 3);
            ProfileEdit.Name = "ProfileEdit";
            ProfileEdit.Size = new Size(51, 23);
            ProfileEdit.TabIndex = 1;
            ProfileEdit.Text = "Edit";
            ProfileEdit.UseVisualStyleBackColor = false;
            ProfileEdit.Click += ProfileEdit_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.BackColor = Color.FromArgb(25, 26, 29);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(NameText);
            panel1.Controls.Add(ProfileEdit);
            panel1.Location = new Point(12, 562);
            panel1.Name = "panel1";
            panel1.Size = new Size(223, 48);
            panel1.TabIndex = 17;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 17, 19);
            ClientSize = new Size(957, 622);
            Controls.Add(ProfilePanel);
            Controls.Add(ServerConnectPanel);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(servers);
            Controls.Add(label2);
            Controls.Add(CCUPANEL);
            Controls.Add(messagelist);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "simac";
            ServerConnectPanel.ResumeLayout(false);
            ServerConnectPanel.PerformLayout();
            ConnectionFeedback.ResumeLayout(false);
            ConnectionFeedback.PerformLayout();
            ProfilePanel.ResumeLayout(false);
            ProfilePanel.PerformLayout();
            servers.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel messagelist;
        private Button connectButton;
        private TextBox textBox1;
        private TextBox NameBox;
        private FlowLayoutPanel CCUPANEL;
        private Label label2;
        private TextBox IPbox;
        private TextBox PORTBOX;
        private FlowLayoutPanel servers;
        private Label label1;
        private FlowLayoutPanel ServerConnectPanel;
        private Label label3;
        private Label NameText;
        private Button ProfileEdit;
        private Panel panel1;
        private FlowLayoutPanel ProfilePanel;
        private Label label4;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button CloseProfile;
        private Button AddServer;
        private FlowLayoutPanel ConnectionFeedback;
        private Label label5;
    }
}

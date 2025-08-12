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
            connectButton = new Button();
            textBox1 = new TextBox();
            NameBox = new TextBox();
            CCUPANEL = new FlowLayoutPanel();
            label2 = new Label();
            IPbox = new TextBox();
            PORTBOX = new TextBox();
            servers = new FlowLayoutPanel();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label3 = new Label();
            flowLayoutPanel1.SuspendLayout();
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
            // NameBox
            // 
            NameBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            NameBox.BackColor = Color.FromArgb(31, 32, 35);
            NameBox.BorderStyle = BorderStyle.FixedSingle;
            NameBox.ForeColor = SystemColors.Info;
            NameBox.Location = new Point(12, 551);
            NameBox.Name = "NameBox";
            NameBox.PlaceholderText = "Name";
            NameBox.Size = new Size(147, 23);
            NameBox.TabIndex = 7;
            NameBox.TextChanged += NameBox_TextChanged;
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
            // servers
            // 
            servers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            servers.AutoScroll = true;
            servers.BorderStyle = BorderStyle.FixedSingle;
            servers.FlowDirection = FlowDirection.TopDown;
            servers.Location = new Point(3, 47);
            servers.Name = "servers";
            servers.Size = new Size(66, 495);
            servers.TabIndex = 14;
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
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel1.BackColor = Color.FromArgb(25, 26, 29);
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(IPbox);
            flowLayoutPanel1.Controls.Add(PORTBOX);
            flowLayoutPanel1.Controls.Add(connectButton);
            flowLayoutPanel1.Location = new Point(12, 408);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(223, 134);
            flowLayoutPanel1.TabIndex = 16;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 17, 19);
            ClientSize = new Size(957, 622);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(label1);
            Controls.Add(servers);
            Controls.Add(label2);
            Controls.Add(CCUPANEL);
            Controls.Add(messagelist);
            Controls.Add(textBox1);
            Controls.Add(NameBox);
            Name = "Form1";
            Text = "simac";
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
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
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label3;
    }
}

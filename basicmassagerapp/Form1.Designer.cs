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
            Sendbtn = new Button();
            NameBox = new TextBox();
            CCUPANEL = new FlowLayoutPanel();
            label2 = new Label();
            IPbox = new TextBox();
            PORTBOX = new TextBox();
            SuspendLayout();
            // 
            // messagelist
            // 
            messagelist.AutoScroll = true;
            messagelist.BackColor = Color.Gray;
            messagelist.FlowDirection = FlowDirection.TopDown;
            messagelist.Location = new Point(252, 12);
            messagelist.Name = "messagelist";
            messagelist.RightToLeft = RightToLeft.No;
            messagelist.Size = new Size(683, 562);
            messagelist.TabIndex = 9;
            messagelist.WrapContents = false;
            // 
            // connectButton
            // 
            connectButton.Location = new Point(165, 548);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(81, 26);
            connectButton.TabIndex = 6;
            connectButton.Text = "Connect";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += ConnectBtn_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F);
            textBox1.Location = new Point(252, 582);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "type your message";
            textBox1.Size = new Size(614, 29);
            textBox1.TabIndex = 0;
            textBox1.KeyDown += textBox1_Enter;
            // 
            // Sendbtn
            // 
            Sendbtn.Location = new Point(872, 585);
            Sendbtn.Name = "Sendbtn";
            Sendbtn.Size = new Size(63, 24);
            Sendbtn.TabIndex = 1;
            Sendbtn.Text = "send";
            Sendbtn.UseVisualStyleBackColor = true;
            Sendbtn.Click += Sendbtn_clicked;
            // 
            // NameBox
            // 
            NameBox.Location = new Point(12, 551);
            NameBox.Name = "NameBox";
            NameBox.PlaceholderText = "Name";
            NameBox.Size = new Size(147, 23);
            NameBox.TabIndex = 7;
            // 
            // CCUPANEL
            // 
            CCUPANEL.AutoScroll = true;
            CCUPANEL.BackColor = Color.Gray;
            CCUPANEL.FlowDirection = FlowDirection.TopDown;
            CCUPANEL.Location = new Point(12, 47);
            CCUPANEL.Name = "CCUPANEL";
            CCUPANEL.Padding = new Padding(10);
            CCUPANEL.Size = new Size(234, 495);
            CCUPANEL.TabIndex = 10;
            CCUPANEL.WrapContents = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(65, 9);
            label2.Name = "label2";
            label2.Size = new Size(121, 28);
            label2.TabIndex = 11;
            label2.Text = "Online Users";
            // 
            // IPbox
            // 
            IPbox.Location = new Point(12, 582);
            IPbox.Name = "IPbox";
            IPbox.PlaceholderText = "IP";
            IPbox.Size = new Size(115, 23);
            IPbox.TabIndex = 12;
            // 
            // PORTBOX
            // 
            PORTBOX.Location = new Point(131, 582);
            PORTBOX.Name = "PORTBOX";
            PORTBOX.PlaceholderText = "port";
            PORTBOX.Size = new Size(115, 23);
            PORTBOX.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.DimGray;
            ClientSize = new Size(957, 622);
            Controls.Add(PORTBOX);
            Controls.Add(IPbox);
            Controls.Add(label2);
            Controls.Add(CCUPANEL);
            Controls.Add(messagelist);
            Controls.Add(textBox1);
            Controls.Add(connectButton);
            Controls.Add(Sendbtn);
            Controls.Add(NameBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel messagelist;
        private Button connectButton;
        private TextBox textBox1;
        private Button Sendbtn;
        private TextBox NameBox;
        private FlowLayoutPanel CCUPANEL;
        private Label label2;
        private TextBox IPbox;
        private TextBox PORTBOX;
    }
}

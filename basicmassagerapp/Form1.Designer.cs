namespace basicmassagerapp
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
            textBox1 = new TextBox();
            Sendbtn = new Button();
            connectButton = new Button();
            NameBox = new TextBox();
            disconnectBtn = new Button();
            massagelist = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(147, 396);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(383, 23);
            textBox1.TabIndex = 0;
            textBox1.KeyDown += textBox1_Enter;
            // 
            // Sendbtn
            // 
            Sendbtn.Location = new Point(536, 396);
            Sendbtn.Name = "Sendbtn";
            Sendbtn.Size = new Size(63, 24);
            Sendbtn.TabIndex = 1;
            Sendbtn.Text = "send";
            Sendbtn.UseVisualStyleBackColor = true;
            Sendbtn.Click += Sendbtn_clicked;
            // 
            // connectButton
            // 
            connectButton.Location = new Point(82, 397);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(55, 21);
            connectButton.TabIndex = 6;
            connectButton.Text = "button1";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += button1_Click;
            // 
            // NameBox
            // 
            NameBox.Location = new Point(5, 397);
            NameBox.Name = "NameBox";
            NameBox.Size = new Size(71, 23);
            NameBox.TabIndex = 7;
            NameBox.Text = "Anonym";
            // 
            // disconnectBtn
            // 
            disconnectBtn.Location = new Point(511, 12);
            disconnectBtn.Name = "disconnectBtn";
            disconnectBtn.Size = new Size(88, 28);
            disconnectBtn.TabIndex = 8;
            disconnectBtn.Text = "disconnect";
            disconnectBtn.UseVisualStyleBackColor = true;
            disconnectBtn.Click += disconnectBtn_Click;
            // 
            // massagelist
            // 
            massagelist.AutoScroll = true;
            massagelist.FlowDirection = FlowDirection.TopDown;
            massagelist.Location = new Point(147, 95);
            massagelist.Name = "massagelist";
            massagelist.RightToLeft = RightToLeft.No;
            massagelist.Size = new Size(452, 282);
            massagelist.TabIndex = 9;
            massagelist.WrapContents = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(611, 450);
            Controls.Add(massagelist);
            Controls.Add(disconnectBtn);
            Controls.Add(NameBox);
            Controls.Add(connectButton);
            Controls.Add(Sendbtn);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button Sendbtn;
        private Button connectButton;
        private TextBox NameBox;
        private Button disconnectBtn;
        private FlowLayoutPanel massagelist;
    }
}

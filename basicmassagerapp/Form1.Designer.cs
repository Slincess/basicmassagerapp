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
            massagelist = new FlowLayoutPanel();
            button1 = new Button();
            NameBox = new TextBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(147, 396);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(383, 23);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
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
            // massagelist
            // 
            massagelist.AutoScroll = true;
            massagelist.AutoSize = true;
            massagelist.FlowDirection = FlowDirection.TopDown;
            massagelist.Location = new Point(147, 54);
            massagelist.Name = "massagelist";
            massagelist.Size = new Size(452, 326);
            massagelist.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(82, 397);
            button1.Name = "button1";
            button1.Size = new Size(55, 21);
            button1.TabIndex = 6;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // NameBox
            // 
            NameBox.Location = new Point(5, 397);
            NameBox.Name = "NameBox";
            NameBox.Size = new Size(71, 23);
            NameBox.TabIndex = 7;
            NameBox.Text = "Anonym";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(611, 450);
            Controls.Add(NameBox);
            Controls.Add(button1);
            Controls.Add(massagelist);
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
        private FlowLayoutPanel massagelist;
        private Button button1;
        private TextBox NameBox;
    }
}

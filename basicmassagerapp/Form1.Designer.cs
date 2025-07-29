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
            checkBox1 = new CheckBox();
            massagelist = new FlowLayoutPanel();
            label1 = new Label();
            massagelist.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(92, 396);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(383, 23);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Sendbtn
            // 
            Sendbtn.Location = new Point(481, 396);
            Sendbtn.Name = "Sendbtn";
            Sendbtn.Size = new Size(63, 24);
            Sendbtn.TabIndex = 1;
            Sendbtn.Text = "send";
            Sendbtn.UseVisualStyleBackColor = true;
            Sendbtn.Click += Sendbtn_clicked;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(481, 12);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(82, 19);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // massagelist
            // 
            massagelist.Controls.Add(label1);
            massagelist.FlowDirection = FlowDirection.TopDown;
            massagelist.Location = new Point(92, 54);
            massagelist.Name = "massagelist";
            massagelist.Size = new Size(452, 326);
            massagelist.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(611, 450);
            Controls.Add(massagelist);
            Controls.Add(checkBox1);
            Controls.Add(Sendbtn);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            massagelist.ResumeLayout(false);
            massagelist.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button Sendbtn;
        private CheckBox checkBox1;
        private FlowLayoutPanel massagelist;
        private Label label1;
    }
}

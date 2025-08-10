namespace basicmessagerapp
{
    public partial class Form1 : Form
    {
        Networking networking;
        NetworkingVariables Networkingvariables;

        public Form1()
        {
            InitializeComponent();
            networking = new();
            networking.Main = this;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (networking.IsClientConnected)
                networking.disconnect();
        }

        private void Sendbtn_clicked(object sender, EventArgs e)
        {
            networking.SendMessage(textBox1.Text);
        }

        private void textBox1_Enter(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                networking.SendMessage(textBox1.Text);
            }
        }

       
        public void ReturnErrorText(string ErrorText)
        {
            this.Invoke((Delegate)(() =>
            {
                MessageList_Add($"CLIENT: {ErrorText}");
            }));
        }

        private bool NameCheck()
        {
            if (String.IsNullOrWhiteSpace(NameBox.Text) || NameBox.Text == "ADMIN")
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public void UpdateUI()
        {
            if (networking.IsClientConnected)
            {
               networking.IsClientConnected = false;
                Sendbtn.Enabled = false;
                NameBox.Enabled = true;
                textBox1.Enabled = false;
                connectButton.Text = "Connect";
            }
            else
            {
                networking.IsClientConnected = true;
                Sendbtn.Enabled = true;
                NameBox.Enabled = false;
                textBox1.Enabled = true;
                connectButton.Text = "Disconnect";
            }
        }

        private async void ConnectBtn_Click(object sender, EventArgs e)
        {
            if (networking.IsClientConnected)
            {
                networking.disconnect();
                networking.IsClientConnected = false;
                Sendbtn.Enabled = false;
                NameBox.Enabled = true;
                textBox1.Enabled = false;
                connectButton.Text = "Connect";
            }
            else
            {
                Networkingvariables.Name = NameBox.Text;
                Networkingvariables.Ip = IPbox.Text;
                Networkingvariables.Port = PORTBOX.Text;
                networking.Variables = Networkingvariables;
                await networking.Connect();
                if(networking.client != null)
                {
                    networking.IsClientConnected = true;
                    Sendbtn.Enabled = true;
                    NameBox.Enabled = false;
                    textBox1.Enabled = true;
                    connectButton.Text = "Disconnect";
                }
            }
        }

        public void MessageList_Add(string text)
        {
            Label message = new();
            message.Text = text;
            message.AutoSize = true;
            message.Font = new Font("Segoe UI", 12F);
            this.Invoke(() =>
            {
                messagelist.Controls.Add(message);
                messagelist.ScrollControlIntoView(messagelist.Controls[messagelist.Controls.Count - 1]);
            });
        }
        public void ClearEveryPanel()
        {
            MessageListClear();
            CCUPanelClear();
        }

        public void MessageListClear()
        {
            this.Invoke(() =>
            {
                messagelist.Controls.Clear();
            });
        }

        public void CCUPanelClear()
        {
            this.Invoke(() =>
            {
                CCUPANEL.Controls.Clear();
            });
        }

        public void CCUList_add(string name)
        {
            FlowLayoutPanel UserPanel = new();
            UserPanel.BackColor = Color.Silver;
            UserPanel.Location = new Point(13, 13);
            UserPanel.Padding = new Padding(10);
            UserPanel.Size = new Size(200, 45);
            UserPanel.TabIndex = 0;

            Label UserNameLable = new();
            UserNameLable.Font = new Font("Segoe UI", 13F);
            UserNameLable.Text = name;
            UserPanel.Controls.Add(UserNameLable);
            this.Invoke(() =>
            {
                CCUPANEL.Controls.Add(UserPanel);
            });
        }
    }
}

public class CL_UserPack
{
    public int CL_ID { get; set; }
    public string? CL_Name { get; set; }
}

public class Users
{
    public List<CL_UserPack> SV_CCU { get; set; }
}

public class DataPacks
{
    public string? Sender { get; set; }
    public string? Message { get; set; }
}


public class SV_Messages
{
    public List<DataPacks> SV_allMessages { get; set; }
}

#pragma warning disable
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.IO.Pipes;
using System.Diagnostics;
namespace basicmessagerapp
{
    public partial class Form1 : Form
    {
        Networking networking;
        NetworkingVariables Networkingvariables;

        UserInfo Info = new();

        public Form1()
        {
            InitializeComponent();
            LoadInfo();
            networking = new();
            networking.Main = this;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (networking.IsClientConnected)
                networking.disconnect();
        }

        private void textBox1_Enter(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                networking.SendMessage(textBox1.Text);
            }
        }

        private void LoadInfo()
        {
            string AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\simac";
            if (Directory.Exists(AppDataPath) && Path.Exists(Path.Combine(AppDataPath, "SimacJson.json")))
            {
                string json = File.ReadAllText(Path.Combine(AppDataPath, "SimacJson.json"));
                Info = JsonSerializer.Deserialize<UserInfo>(json) ?? new UserInfo();
                NameBox.Text = Info.LastName;
            }
            else
            {
                string newJson = JsonSerializer.Serialize(Info);
                if (!Path.Exists(Path.Combine(AppDataPath, "SimacJson.json")))
                    Directory.CreateDirectory(AppDataPath);

                File.WriteAllText(@$"{AppDataPath}\SimacJson.json", newJson);
            }
        }

        private void SaveInfo(UserInfo info)
        {
            string AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\simac";
            if (Directory.Exists(AppDataPath) && Path.Exists(Path.Combine(AppDataPath, "SimacJson.json")))
            {
                string infojson = JsonSerializer.Serialize(info);

                File.WriteAllText(Path.Combine(AppDataPath, "SimacJson.json"),infojson);
            }
            else
            {
                UserInfo infoNew = new();
                string newJson = JsonSerializer.Serialize(infoNew);
                if (!Path.Exists(Path.Combine(AppDataPath, "SimacJson.json")))
                    Directory.CreateDirectory(AppDataPath);

                File.WriteAllText(@$"{AppDataPath}\SimacJson.json", newJson);
            }
        }

        public void ReturnErrorText(string ErrorText)
        {
            this.Invoke((Delegate)(() =>
            {
                MessageList_Add($"CLIENT: {ErrorText}");
            }));
        }

        public void UpdateUI()
        {
            if (networking.IsClientConnected)
            {
                networking.IsClientConnected = false;
                NameBox.Enabled = true;
                textBox1.Enabled = false;
                connectButton.Text = "Connect";
            }
            else
            {
                networking.IsClientConnected = true;
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
                if (networking.client != null)
                {
                    networking.IsClientConnected = true;
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
            if (text.Contains("SERVER:"))
            {
                message.ForeColor = Color.FromArgb(111, 168, 168);
            }
            else
            {
                message.ForeColor = Color.White;
            }
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
            UserPanel.BackColor = Color.FromArgb(44, 44, 47);
            UserPanel.Location = new Point(13, 13);
            UserPanel.Padding = new Padding(10);
            UserPanel.Size = new Size(157, 45);
            UserPanel.TabIndex = 0;

            Label UserNameLable = new();
            UserNameLable.Font = new Font("Segoe UI", 13F);
            UserNameLable.Text = name;
            UserNameLable.ForeColor = Color.White;
            UserPanel.Controls.Add(UserNameLable);
            this.Invoke(() =>
            {
                CCUPANEL.Controls.Add(UserPanel);
            });
        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {
            Info.LastName = NameBox.Text;
            SaveInfo(Info);
        }
    }
}

public class UserInfo
{
   public List<string> ServerIPs { get; set; } = new();
   public string LastName { get; set; } = "anonym";
}

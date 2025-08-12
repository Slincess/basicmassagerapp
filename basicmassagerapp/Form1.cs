#pragma warning disable
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.IO.Pipes;
using System.Diagnostics;

//todo:
//join more servers
//change between servers and still have the chats
//SERVER: send only last 30 messages
//collect last 30 message in catch or maybe create panel for every server.
namespace basicmessagerapp
{
    public partial class Form1 : Form
    {
        Networking networking;
        NetworkingVariables Networkingvariables;

        public UserInfo Info = new();

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
                NameText.Text = Info.LastName;
                if(Info.ServerIPs.Count > 0)
                {
                    foreach (var item in Info.ServerIPs)
                    {
                        servers.Controls.Add(new Button
                        {
                            BackColor = Color.FromArgb(64, 65, 68),
                            FlatStyle = FlatStyle.Flat,
                            Font = new Font("Segoe UI", 11F),
                            ForeColor = SystemColors.Control,
                            Location = new Point(3, 3),
                            Name = item.IP,
                            Size = new Size(54, 36),
                            TabIndex = 0,
                            Text = item.IP,
                            UseVisualStyleBackColor = false
                        });
                    }
                }
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

                File.WriteAllText(Path.Combine(AppDataPath, "SimacJson.json"), infojson);
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
            ConnectionFeedBackClear();
            if (CheckAlreadyJoined(IPbox.Text, PORTBOX.Text) && !String.IsNullOrWhiteSpace(Info.LastName))
            {
                int port;
                if (int.TryParse(PORTBOX.Text, out port))
                {
                    if (await networking.Connect(IPbox.Text, port))
                    {
                        ConnectFeedback("Connected!");
                        Server ConnectedServer = new();
                        ConnectedServer.IP = IPbox.Text;
                        ConnectedServer.Port = port;
                        Info.ServerIPs.Add(ConnectedServer);
                        servers.Controls.Add(new Button
                        {
                            BackColor = Color.FromArgb(64, 65, 68),
                            FlatStyle = FlatStyle.Flat,
                            Font = new Font("Segoe UI", 11F),
                            ForeColor = SystemColors.Control,
                            Location = new Point(3, 3),
                            Name = IPbox.Text,
                            Size = new Size(54, 36),
                            TabIndex = 0,
                            Text = IPbox.Text,
                            UseVisualStyleBackColor = false
                        });
                        SaveInfo(Info);
                    }
                    else 
                    {
                        ConnectFeedback("couldnt connect, wrong Ip or port");
                    }
                }
            }
            else if (String.IsNullOrWhiteSpace(Info.LastName)) { ConnectFeedback("name is missing"); }
            else{ ConnectFeedback("Ip or Port Missing"); }
        }

        private void ConnectFeedback(string Feedback)
        {
            this.Invoke(() =>
            {
                Label ConnectionFeedBackText = new();
                ConnectionFeedBackText.AutoSize = true;
                ConnectionFeedBackText.Font = new Font("Segoe UI", 10F);
                ConnectionFeedBackText.ForeColor = SystemColors.Control;
                ConnectionFeedBackText.Location = new Point(3, 3);
                ConnectionFeedBackText.Margin = new Padding(3, 3, 3, 0);
                ConnectionFeedBackText.Name = "ConnectionFeedBackText";
                ConnectionFeedBackText.Size = new Size(45, 19);
                ConnectionFeedBackText.TabIndex = 0;
                ConnectionFeedBackText.Text = Feedback;
                ConnectionFeedback.Controls.Add(ConnectionFeedBackText);
            });
        }

        private bool CheckAlreadyJoined(string ip,string portString)
        {
            int port;
            bool suc;
            if(suc = int.TryParse(portString,out port))
            {
                foreach (var item in Info.ServerIPs)
                {
                    if (ip != item.IP && port != item.Port)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                ConnectFeedback("invalid Port");
                return false;
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
            ConnectionFeedBackClear();
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

        public void ConnectionFeedBackClear()
        {
            ConnectionFeedback.Controls.Clear();
        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {
            Info.LastName = NameBox.Text;
            SaveInfo(Info);
        }

        private void ProfileEdit_Click(object sender, EventArgs e)
        {
            ProfilePanel.Visible = true;
            ServerConnectPanel.Visible = false;
        }

        private void CloseProfile_Click(object sender, EventArgs e)
        {
            NameText.Text = Info.LastName;
            ProfilePanel.Visible = false;
            ServerConnectPanel.Visible = false;
        }

        private void AddServer_Click(object sender, EventArgs e)
        {
            ProfilePanel.Visible = false;
            ServerConnectPanel.Visible = true;
        }
    }
}

public class UserInfo
{
    public List<Server> ServerIPs { get; set; } = new();
    public string LastName { get; set; } = "anonym";
}

public class Server
{
    public string IP { get; set; }
    public int Port { get; set; }
}

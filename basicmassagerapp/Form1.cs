#pragma warning disable
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.IO.Pipes;
using System.Diagnostics;
using basicmessagerapp;
using System.Linq;

//todo:
//join more servers
//change between servers and still have the chats
//SERVER: send only last 30 messages
//collect last 30 message in catch or maybe create panel for every server.
namespace basicmessagerapp
{
    public partial class Form1 : Form
    {
        List<Networking> networks = new();
        NetworkingVariables Networkingvariables;
        public Networking currentUsedNetwork;
        public List<ServerBtns> Servers = new();

        public UserInfo Info = new();

        public Form1()
        {
            InitializeComponent();
            LoadInfo();
            foreach (var item in Servers)
            {
                item.main = this;
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            foreach (var item in networks)
            {
                if (item.IsClientConnected)
                    item.disconnect();
            }
        }

        private void textBox1_Enter(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                currentUsedNetwork.SendMessage(textBox1.Text);
            }
        }

        private void LoadInfo()
        {
            string AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\simac";
            if (Directory.Exists(AppDataPath) && Path.Exists(Path.Combine(AppDataPath, "SimacJson.json")))
            {
                HandleServers();
            }
            else
            {
                string newJson = JsonSerializer.Serialize(Info);
                if (!Path.Exists(Path.Combine(AppDataPath, "SimacJson.json")))
                    Directory.CreateDirectory(AppDataPath);

                File.WriteAllText(@$"{AppDataPath}\SimacJson.json", newJson);
            }
        }

        private void ServerButtonClicked(object? sender, EventArgs e)
        {
            
        }

        private void HandleServers()
        {
            string AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\simac";
            string json = File.ReadAllText(Path.Combine(AppDataPath, "SimacJson.json"));
            Info = JsonSerializer.Deserialize<UserInfo>(json) ?? new UserInfo();
            NameBox.Text = Info.LastName;
            NameText.Text = Info.LastName;
            if (Info.ServerIPs.Count > 0)
            {
                foreach (var item in Info.ServerIPs)
                {
                    CreateServer(item);
                }
            }
        }

        private async Task<bool> CreateServer(Server Server)
        {
            Button btn = new Button
            {
                BackColor = Color.FromArgb(64, 65, 68),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F),
                ForeColor = SystemColors.Control,
                Location = new Point(3, 3),
                Name = Server.IP,
                Size = new Size(54, 36),
                TabIndex = 0,
                Text = Server.IP,
                UseVisualStyleBackColor = false
            };
            ServerBtns serverbtn = new();
            serverbtn.networking.Main = this;
            serverbtn.ServerListIndex = serverbtn.ServerListIndex + 1;
            serverbtn.networking.serverbtn = serverbtn;
            try
            {
                serverbtn.networking.Connect(Server.IP, Server.Port);
            }
            catch (Exception)
            {
                return false;
            }
            serverbtn.CCUPanel = new FlowLayoutPanel
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left,
                AutoScroll = true,
                BackColor = Color.FromArgb(17, 17, 19),
                BorderStyle = BorderStyle.FixedSingle,
                FlowDirection = FlowDirection.TopDown,
                Location = new Point(75, 47),
                Name = "CCUPANEL",
                Padding = new Padding(10),
                Size = new Size(181, 495),
                TabIndex = 10,
                WrapContents = false,
                Visible =false
            };

            serverbtn.messagelist = new FlowLayoutPanel
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                AutoScroll = true,
                BackColor = Color.FromArgb(25, 26, 29),
                BorderStyle = BorderStyle.FixedSingle,
                FlowDirection = FlowDirection.TopDown,
                Location = new Point(262, 12),
                Name = "messagelist",
                RightToLeft = RightToLeft.No,
                Size = new Size(683, 562),
                TabIndex = 9,
                WrapContents = false,
                Visible = false
            };

            this.Controls.Add(serverbtn.messagelist);
            this.Controls.Add(serverbtn.CCUPanel);

            btn.Click += serverbtn.ServerButtonClicked;
            servers.Controls.Add(btn);
            Servers.Add(serverbtn);

            return true;
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
                currentUsedNetwork.serverbtn.MessageList_Add($"CLIENT: {ErrorText}");
            }));
        }

        public void UpdateUI()
        {
            NameBox.Enabled = !currentUsedNetwork.IsClientConnected;
            textBox1.Enabled = !currentUsedNetwork.IsClientConnected;
        }

        private async void ConnectBtn_Click(object sender, EventArgs e)
        {
            ConnectionFeedBackClear();
            if (CheckAlreadyJoined(IPbox.Text, PORTBOX.Text) && !String.IsNullOrWhiteSpace(Info.LastName))
            {
                int port;
                if (int.TryParse(PORTBOX.Text, out port))
                {
                    Networking network = new();
                    networks.Add(network);
                    Server ConnectedServer = new();
                    ConnectedServer.IP = IPbox.Text;
                    ConnectedServer.Port = port;
                    if (await CreateServer(ConnectedServer))
                    {
                        ConnectFeedback("Connected!");
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

public class ServerBtns
{
    public int ServerListIndex;
    public Networking networking = new();
    public FlowLayoutPanel CCUPanel;
    public FlowLayoutPanel messagelist;
    public Form1 main;
    private void ClosePanels()
    {
        CCUPanel.Visible = false;
        messagelist.Visible = false;
    }
    private void OpenPanels()
    {
        CCUPanel.Visible = true;
        messagelist.Visible = true;
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
        CCUPanel.Controls.Add(UserPanel);
       
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
            messagelist.Controls.Add(message);
            messagelist.ScrollControlIntoView(messagelist.Controls[messagelist.Controls.Count - 1]);
    }
    public void ServerButtonClicked(object? sender, EventArgs e)
    {
        foreach (var item in main.Servers)
        {
            item.ClosePanels();
        }
        main.currentUsedNetwork = networking;
        OpenPanels();
    }
}
using basicmessagerapp;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace basicmessagerapp
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        CancellationTokenSource cts;

        private byte[] message;
        private List<DataPacks> datapacks = new();
        private DataPacks MyData;

        private Task response;

        private bool IsClientConnected = false;
        private int messagesCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (IsClientConnected)
                disconnect();
        }

        private void Sendbtn_clicked(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void textBox1_Enter(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendMessage();
            }
        }

        private void SendMessage()
        {
            if(!String.IsNullOrWhiteSpace(textBox1.Text))
            {
                DataPacks data = new();
                data.CL_Name = NameBox.Text;
                data.Message = textBox1.Text;

                string dataJson = JsonSerializer.Serialize(data);

                try
                {
                    message = Encoding.UTF8.GetBytes(dataJson);
                    stream.Write(message, 0, message.Length);
                    textBox1.Text = null;
                }
                catch (Exception e)
                {
                        disconnect();
                    
                }
            }
        }

        private void getmessages()
        {

            while (client.Connected)
            {
                byte[] response_byte = new byte[5000];
                int response_int = 0;
                try
                {
                    response_int = stream.Read(response_byte);
                }
                catch (Exception)
                {
                    disconnect();
                }
                string response_string = Encoding.UTF8.GetString(response_byte, 0, response_int);
                if (response_int == 0)
                {
                    break;
                }
                if (messagesCount == 0)
                {
                    messagesCount++;
                    SV_Messages Sv_messages = JsonSerializer.Deserialize<SV_Messages>(response_string);
                    Console.WriteLine(Sv_messages);
                    try
                    {
                        if (Sv_messages.SV_allMessages != null)
                        {
                            foreach (var item in Sv_messages.SV_allMessages)
                            {
                                Debug.WriteLine(item.Message);
                                this.Invoke((Delegate)(() =>
                                {
                                    MessageList_Add(item.sender + ": " + item.Message);
                                }));
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.Write(e);
                    }
                }
                else
                {
                    if (response_string.Contains("SV_CCU"))
                    {
                        CCUPANEL.Controls.Clear();
                        Users CurrentUsers = JsonSerializer.Deserialize<Users>(response_string);
                        if (CurrentUsers.SV_CCU != null)
                        {
                            foreach (var item in CurrentUsers.SV_CCU)
                            {
                                this.Invoke((Delegate)(() =>
                                {
                                    CCUList_add(item.CL_Name);
                                }));
                            }
                        }
                    }
                    if (response_string.Contains("Message"))
                    {
                        DataPacks response_string_Deserialized = JsonSerializer.Deserialize<DataPacks>(response_string);
                        if (response_string_Deserialized.Message == "__KICK__" && response_string_Deserialized.CL_Name == "__SERVER__")
                        {
                            disconnect();
                        }
                        else
                        {
                            this.Invoke((Delegate)(() =>
                            {
                                MessageList_Add(response_string_Deserialized.CL_Name + ": " + response_string_Deserialized.Message);
                            }));
                        }
                    }
                }
            }
        }

        private void disconnect()
        {
            if (IsClientConnected && stream != null)
            {
                DataPacks disconnectedSignal = new()
                {
                    CL_Name = "ADMIN",
                    Message = "__DISCONNECT__"
                };
                string disconnectedsignal_json = JsonSerializer.Serialize(disconnectedSignal);
                byte[] disconnectedsignal_byte = Encoding.UTF8.GetBytes(disconnectedsignal_json);
                try
                {
                    stream.Write(disconnectedsignal_byte, 0, disconnectedsignal_byte.Length);
                }
                catch (Exception)
                {
                    client.Close();
                    messagelist.Controls.Clear();
                    messagesCount = 0;
                    CCUPANEL.Controls.Clear();
                    IsClientConnected = false;
                    UpdateUI();
                    return;
                }
                Thread.Sleep(100);
                client.GetStream().Close();
                client.Close();
                messagelist.Controls.Clear();
                messagesCount = 0;
                CCUPANEL.Controls.Clear();
            }
        }

        private async Task Connect()
        {
            try
            {
                if (NameBox.Text != null && PORTBOX.Text != null && IPbox.Text != null)
                {
                    if(!NameCheck()) {ReturnErrorText("Name Is Missing"); return; }
                    int port;
                    bool suc = int.TryParse(PORTBOX.Text, out port);
                    byte[] name = new byte[5000];
                    name = Encoding.UTF8.GetBytes(NameBox.Text);
                    client = new TcpClient(IPbox.Text, port);
                    stream = client.GetStream();
                    cts = new CancellationTokenSource();
                    response = Task.Run(() => getmessages());
                    stream.Write(name, 0, name.Length);
                }
                else
                {
                    ReturnErrorText("wrong or missing ip and port or missing name");
                }
            }
            catch
            {
                ReturnErrorText("wrong/missing port or ip");
            }
        }

        private void ReturnErrorText(string ErrorText)
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


        private void UpdateUI()
        {
            if (IsClientConnected)
            {
                IsClientConnected = false;
                Sendbtn.Enabled = false;
                NameBox.Enabled = true;
                textBox1.Enabled = false;
                connectButton.Text = "Connect";

            }
            else
            {
                    IsClientConnected = true;
                    Sendbtn.Enabled = true;
                    NameBox.Enabled = false;
                    textBox1.Enabled = true;
                    connectButton.Text = "Disconnect";
                
            }
        }

        private async void ConnectBtn_Click(object sender, EventArgs e)
        {
            if (IsClientConnected)
            {
                    disconnect();
                    IsClientConnected = false;
                    Sendbtn.Enabled = false;
                    NameBox.Enabled = true;
                    textBox1.Enabled = false;
                    connectButton.Text = "Connect";
                
            }
            else
            {
                await Connect();
                if(client != null)
                {
                    IsClientConnected = true;
                    Sendbtn.Enabled = true;
                    NameBox.Enabled = false;
                    textBox1.Enabled = true;
                    connectButton.Text = "Disconnect";
                }
            }
        }

        private void MessageList_Add(string text)
        {
            Label message = new();
            message.Text = text;
            message.AutoSize = true;
            message.Font = new Font("Segoe UI", 12F);
            messagelist.Controls.Add(message);
            messagelist.ScrollControlIntoView(messagelist.Controls[messagelist.Controls.Count - 1]);
        }

        private void CCUList_add(string name)
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
            CCUPANEL.Controls.Add(UserPanel);
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
    public string? CL_Name { get; set; }
    public string? Message { get; set; }
}

public class SV_Messages
{
    public List<message> SV_allMessages { get; set; }
}

public class message
{

    public string? Message { get; set; }
    public string? sender { get; set; }
    public string? Hour { get; set; }
}

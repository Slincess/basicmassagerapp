using basicmassagerapp;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace basicmassagerapp
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        CancellationTokenSource cts;

        private byte[] massage;
        private List<DataPacks> datapacks = new();
        private DataPacks MyData;

        private Task response;

        private bool IsClientConnected = false;
        private int massagesCount = 0;

        public Form1()
        {
            InitializeComponent();
            Sendbtn.Enabled = false;
            NameBox.Enabled = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (IsClientConnected)
                disconnect();
        }

        private void Sendbtn_clicked(object sender, EventArgs e)
        {
            SendMassage();
        }

        private void textBox1_Enter(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SendMassage();
            }
        }

        private void SendMassage()
        {
            DataPacks data = new();
            data.CL_Name = NameBox.Text;
            data.Massage = textBox1.Text;

            string dataJson = JsonSerializer.Serialize(data);


            massage = Encoding.UTF8.GetBytes(dataJson);
            stream.Write(massage, 0, massage.Length);
            textBox1.Text = null;
        }

        private void getmassages()
        {

            while (client.Connected)
            {
                byte[] response_byte = new byte[5000];
                int response_int = stream.Read(response_byte);
                string response_string = Encoding.UTF8.GetString(response_byte, 0, response_int);
                if (response_int == 0)
                {
                    break;
                }
                if (massagesCount == 0)
                {
                    SV_Massages Sv_massages = JsonSerializer.Deserialize<SV_Massages>(response_string);
                    Console.WriteLine(Sv_massages);
                    try
                    {
                        if(Sv_massages.SV_allMassages != null)
                        {
                            foreach (var item in Sv_massages.SV_allMassages)
                            {
                                Console.WriteLine(item.Massage);
                                this.Invoke((Delegate)(() =>
                                {
                                    MassageList_Add(item.sender + ": " + item.Massage);
                                }));
                            }
                        }
                    }
                    catch { }
                    massagesCount++;
                }
                else
                {
                    if (response_string.Contains("SV_CCU"))
                    {
                        Users CurrentUsers = JsonSerializer.Deserialize<Users>(response_string);
                        if (CurrentUsers.SV_CCU != null)
                        {
                            foreach (var item in CurrentUsers.SV_CCU)
                            {
                                this.Invoke((Delegate)(() =>
                                {
                                    CCUList_add(item.CL_Name);
                                    MassageList_Add(item.CL_Name);
                                }));
                            }
                        }
                    }
                    if (response_string.Contains("Massage"))
                    {
                        DataPacks response_string_Deserialized = JsonSerializer.Deserialize<DataPacks>(response_string);
                        this.Invoke((Delegate)(() =>
                        {
                            MassageList_Add(response_string_Deserialized.CL_Name + ": " + response_string_Deserialized.Massage);
                        }));
                    }
                }
            }
        }

        private void disconnect()
        {
            DataPacks disconnectedSignal = new()
            {
                CL_Name = "ADMIN",
                Massage = "__DISCONNECT__"
            };
            string disconnectedsignal_json = JsonSerializer.Serialize(disconnectedSignal);
            byte[] disconnectedsignal_byte = Encoding.UTF8.GetBytes(disconnectedsignal_json);
            stream.Write(disconnectedsignal_byte, 0, disconnectedsignal_byte.Length);
            Thread.Sleep(100);
            client.GetStream().Close();
            client.Close();
            massagelist.Controls.Clear();
            massagesCount = 0;
        }

        private void Connect()
        {
            byte[] name = new byte[5000];
            name = Encoding.UTF8.GetBytes(NameBox.Text);
            client = new TcpClient("127.0.0.1", 5000);
            //client = new TcpClient("192.168.178.55", 5000);
            stream = client.GetStream();
            cts = new CancellationTokenSource();
            response = Task.Run(() => getmassages());
            //sresponse.Start();
            stream.Write(name, 0, name.Length);

            this.Invoke((Delegate)(() =>
            {
                MassageList_Add("Connected");
            }));
        }




        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            if (IsClientConnected)
            {
                disconnect();
                IsClientConnected = false;
                Sendbtn.Enabled = false;
                NameBox.Enabled = true;
                textBox1.Enabled = false;
            }
            else
            {
                Connect();
                IsClientConnected = true;
                Sendbtn.Enabled = true;
                NameBox.Enabled = false;
                textBox1.Enabled = true;
            }
        }

        private void MassageList_Add(string text)
        {
            Label massage = new();
            massage.Text = text;
            massage.AutoSize = true;
            massage.Font = new Font("Segoe UI", 12F);
            massagelist.Controls.Add(massage);
        }

        private void CCUList_add(string name)
        {
            FlowLayoutPanel UserPanel = new();
            UserPanel.BackColor = Color.Silver;
            UserPanel.Controls.Add(label1);
            UserPanel.Location = new Point(13, 13);
            UserPanel.Padding = new Padding(10);
            UserPanel.Size = new Size(200, 45);
            UserPanel.TabIndex = 0;

            Label UserNameLable = new();
            UserNameLable.Font = new Font("Segoe UI", 13F);
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
    public string? Massage { get; set; }
}

public class SV_Massages
{
    public List<massage> SV_allMassages { get; set; }
}

public class massage
{
    public string? Massage { get; set; }
    public string? sender { get; set; }
    public string? Hour { get; set; }
}

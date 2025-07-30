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

        public Form1()
        {
            InitializeComponent();
            Sendbtn.Enabled = false;
            disconnectBtn.Enabled = false;
            connectButton.Enabled = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            disconnect();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //massage = Encoding.UTF8.GetBytes(textBox1.Text);
        }

        private void Sendbtn_clicked(object sender, EventArgs e)
        {
            DataPacks data = new();
            data.CL_Name = NameBox.Text;
            data.Massage = textBox1.Text;

            string dataJson = JsonSerializer.Serialize(data);


            massage = Encoding.UTF8.GetBytes(dataJson);
            stream.Write(massage, 0, massage.Length);
        }

        private void getmassages()
        {
            while (IsClientConnected)
            {
                byte[] response_byte = new byte[5000];
                int response_int = stream.Read(response_byte);
                if (response_int == 0)
                {
                    break;
                }

                string response_string = Encoding.UTF8.GetString(response_byte, 0, response_int);
                DataPacks response_string_Deserialized = JsonSerializer.Deserialize<DataPacks>(response_string);
                this.Invoke(() =>
                {
                    Label massage = new();
                    massage.Text = response_string_Deserialized.CL_Name + ": " + response_string_Deserialized.Massage;
                    massage.AutoSize = true;
                    massagelist.Controls.Add(massage);
                });
            }
        }

        private void disconnect()
        {
            IsClientConnected = false;
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
            Sendbtn.Enabled = false;
            disconnectBtn.Enabled = false;
            connectButton.Enabled = true;
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
            Sendbtn.Enabled = true;
            disconnectBtn.Enabled = true;
            connectButton.Enabled = false;
        }



        private void disconnectBtn_Click(object sender, EventArgs e)
        {
            disconnect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connect();
        }
    }
}

public class UserPack()
{
    public string? CL_Name;
    public List<string> Massages = new List<string>();
}

public class DataPacks
{
    public string? CL_Name { get; set; }
    public string? Massage { get; set; }
}

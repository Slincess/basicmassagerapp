using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace basicmassagerapp
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        CancellationTokenSource cts;

        private byte[] massage;
        private massage[] receivedMassages;

        public Form1()
        {
            InitializeComponent();
            Connect();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            massage = Encoding.UTF8.GetBytes(textBox1.Text);
        }

        private void Sendbtn_clicked(object sender, EventArgs e)
        {
            stream.Write(massage, 0, massage.Length);
        }

        private void getmassages()
        {
            while (client.Connected)
            {
                byte[] response_byte = new byte[1024];
                int response_int = stream.Read(response_byte);

                string response_string = Encoding.UTF8.GetString(response_byte, 0, response_int);
                this.Invoke(() =>
                {
                    Label massage = new();
                    massage.Text = response_string;
                    massage.AutoSize = true;
                    massagelist.Controls.Add(massage);
                });
            }
        }

        private void Connect()
        {
            byte[] name = new byte[1024];
            name = Encoding.UTF8.GetBytes("testerone");
            client = new TcpClient("127.0.0.1", 5000);
            stream = client.GetStream();
            cts = new CancellationTokenSource();
            Task response = new Task(() => getmassages());
            response.Start();
            stream.Write(name, 0, name.Length);

        }

        private void massageList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

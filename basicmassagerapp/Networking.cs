#pragma warning disable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace basicmessagerapp
{
    public class Networking
    {
        public NetworkingVariables Variables;
        public Form1 Main;

        public TcpClient client { get; private set; }
        private NetworkStream stream;
        CancellationTokenSource cts;

        private byte[] message;
        private List<DataPacks> datapacks = new();
        private DataPacks MyData;

        public Task response;

        public bool IsClientConnected = false;
        private int messagesCount = 0;

        public async Task Connect()
        {
            if (!NameCheck()) { return; }
            int port;
            bool suc = int.TryParse(Variables.Port, out port);
            byte[] name = new byte[5000];
            name = Encoding.UTF8.GetBytes(Variables.Name);
            client = new TcpClient(Variables.Ip, port);
            stream = client.GetStream();
            cts = new CancellationTokenSource();
            response = Task.Run(() => getmessages());
            stream.Write(name, 0, name.Length);    
        }

        public void disconnect()
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
                    messagesCount = 0;
                    Main.ClearEveryPanel();
                    IsClientConnected = false;
                    Main.UpdateUI();
                    return;
                }
                Thread.Sleep(100);
                client.GetStream().Close();
                client.Close();
                messagesCount = 0;
                Main.ClearEveryPanel();
            }
        }

        private bool NameCheck()
        {
            if (String.IsNullOrWhiteSpace(Variables.Name) || Variables.Name == "ADMIN")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void getmessages()
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
                                Main.MessageList_Add(item.sender + ": " + item.Message);
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
                        Main.CCUPanelClear();
                        Users CurrentUsers = JsonSerializer.Deserialize<Users>(response_string);
                        if (CurrentUsers.SV_CCU != null)
                        {
                            foreach (var item in CurrentUsers.SV_CCU)
                            {
                                
                                    Main.CCUList_add(item.CL_Name);
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
                              Main.MessageList_Add(response_string_Deserialized.CL_Name + ": " + response_string_Deserialized.Message);

                        }
                    }
                }
            }
        }

        public void SendMessage(string Message)
        {
            if (!String.IsNullOrWhiteSpace(Variables.Name))
            {
                DataPacks data = new();
                data.CL_Name = Variables.Name;
                data.Message = Message;

                string dataJson = JsonSerializer.Serialize(data);

                try
                {
                    message = Encoding.UTF8.GetBytes(dataJson);
                    stream.Write(message, 0, message.Length);
                }
                catch (Exception e)
                {
                    disconnect();
                }
            }
        }
    }
}

public struct NetworkingVariables
{
    public string Name;
    public string Port;
    public string Ip;
    public TcpClient client;
    public NetworkStream? stream;
}
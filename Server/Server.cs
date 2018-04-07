using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;


namespace Server
{
    public partial class Server : Form
    {
        
        IPEndPoint IPE;
        IPAddress IP;
        int Port;
        Socket server;
        List<Socket> clientList;

        //User server
        CUser user;
        //Text formating 
        Color __color = Color.Black;
        string fontFamily = "Arial";
        float size = 10;


        public Server(string IPServer, int PortServer)
        {
            InitializeComponent();
            IP = IPAddress.Parse(IPServer);
            Port = PortServer;
            //Init server
            Connect();
            //Load font
            LoadFont();
            
        }



        private void btnSend_Click(object sender, EventArgs e)
        {
            this.user.setMessage(txbMessage.Text);
            Send(this.user);
            addMsg(this.user);
            txbMessage.Clear();
        }
        //Get ip local
        private string GetIPLocal()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();

            return "127.0.0.1";
        }
        void Connect()
        {
            clientList = new List<Socket>();
            //IP của Server
            this.Text = "Máy chủ[" + IP.ToString() + "]";
            //Chỉ chấp nhận những client kết nối đến IP của server
            IPE = new IPEndPoint(IP, Port);
            //Khởi tạo user server
            user = new CUser("Server",IP);

            server = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            server.Bind(IPE);
            
            Thread Listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();
                        //Thong bao co nguoi vao nhom
                        rtbMessage.AppendText(client.RemoteEndPoint.ToString() + " Đã tham gia vào nhóm chat" + Environment.NewLine);
                        //THem vao list client
                        clientList.Add(client);
                        //Them vao list danh sach ket noi
                        listMember.Items.Insert(listMember.Items.Count,client.RemoteEndPoint.ToString());
                        Thread recevie = new Thread(Receive);
                        recevie.IsBackground = true;
                        recevie.Start(client);
                        

                    }
                }
                catch
                {
                    IPE = new IPEndPoint(IP, 7777);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    //server.Bind(IPE);
                }
            });

            Listen.IsBackground = true;
            Listen.Start();
        }

        void Close()
        {
            server.Close();
        }

        void Send(CUser infoUser)
        {
            //input info for user
            this.user.message= txbMessage.Text;
            this.user._color = __color;
            this.user.fontFamily = fontFamily;
            this.user.size = size;
            //Send message to all client
            foreach (Socket item in clientList)
            {
                if (infoUser.getMessage() != string.Empty)
                    item.Send(Serialize(infoUser));
            }

        }
        void Receive( object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    CUser infoUser = (CUser)Deserialize(data);

                    //khu vuc test
                    Send(infoUser);
                    //khu vuc test
                    addMsg(infoUser);
                }
            }
            catch 
            {
                clientList.Remove(client);
                client.Close();
            }
            
        }

        void addMsg(CUser user)
        {
            rtbMessage.SelectionFont = new Font(new FontFamily(user.fontFamily), user.size);
            rtbMessage.SelectionColor = user._color;
            rtbMessage.AppendText(user.nickname + ":" + user.message + Environment.NewLine);
            rtbMessage.ScrollToCaret();

            txbMessage.Clear();
        }

        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);
            return stream.ToArray();
        }

        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream);
             
        }

        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        //Load font family
        private void LoadFont()
        {
            foreach (FontFamily font in FontFamily.Families)
            {
                cbxFont.Items.Add(font.Name.ToString());
                
            }
        }

        //Pick color for message
        private void pColor_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                __color = colorDialog1.Color;
                pColor.BackColor = __color;
            }
        }

        private void cbxFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fontFamily = cbxFont.Text;
            }
            catch
            { }
        }

        private void cbxSize_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                size = float.Parse(cbxSize.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:"+ex, "Xuất hiện lỗi!");
            }
        }

         

        string KickIP = null;
        int idKick = -1;
        private void btnKick_Click(object sender, EventArgs e)
        {
            if (this.KickIP != null && this.idKick >= 0)
            {
                foreach (Socket client in clientList)
                {
                    if (client.RemoteEndPoint.ToString() == this.KickIP)
                    {
                        client.Close();
                        break;
                    }
                }
                listMember.Items.RemoveAt(this.idKick);
            }
        }

        
        private void listMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(listMember.SelectedIndex >= 0)
                {
                    this.KickIP = listMember.SelectedItem.ToString();
                    this.idKick = int.Parse(listMember.SelectedIndex.ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi tại đây");
            }
        }

      


    }
}

using System;
using System.Windows.Forms;


using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

using Server;
using System.Drawing;

namespace Client
{
    public partial class Client : Form
    {
        
        IPEndPoint IP;
        Socket client;

        //User
        public CUser user;
        //Text formatting init
        Color __color = Color.Black;
        string fontFamily = "Arial";
        float size = 10;


        public Client(CUser a)
        {
            InitializeComponent();
            //Use info user
            this.user = a;

            
            
            //Connect to server
            Connect();
            //Load font to combobox
            LoadFont();
        }
        void Connect()
        {
            //IP địa chỉ của Server
            
            IP = new IPEndPoint(this.user.IPServer, this.user.port);
            client = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);

            try
            {
                client.Connect(IP);
                this.user.IPLocal = client.LocalEndPoint.ToString();
                //Set up title form
                this.Text += " [" + this.user.nickname + " : " + client.LocalEndPoint + "]";

                MessageBox.Show("Kết nối thành công", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Không thể kết nối server!", "Lỗi");
                Application.Exit();
                this.Close();
                return;
            }

            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();
        }

        //Close socket
        void Close()
        {
            client.Close();
        }

        void Send()
        {
            //input info for user
            this.user.setMessage(txbMessage.Text);
            this.user._color = __color;
            this.user.fontFamily = fontFamily;
            this.user.size = size;
            //Send to server
            if (this.user.getMessage() != string.Empty)
            {
                try
                {
                    client.Send(Serialize(user));
                }
                catch
                {
                    MessageBox.Show("Bạn đã bị kick khỏi nhóm chat", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
                
        }
        
        //Add message to listbox
        void addMsg(CUser user) {

            rtbMessage.SelectionFont = new Font(new FontFamily(user.fontFamily), user.size);
            rtbMessage.SelectionColor = user._color;
            rtbMessage.AppendText(user.nickname + ":" + user.message + Environment.NewLine);
            rtbMessage.ScrollToCaret();

            txbMessage.Clear();
        }

        void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    CUser infoUser = (CUser)Deserialize(data);
                    addMsg(infoUser);
                }
            }
            catch
            {
                Close();
            }

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

        //Send message
        private void btnSend_Click(object sender, EventArgs e)
        {
            Send();
        }

        //Turn off application
        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            Application.Exit();
        }
        
        //Load font family
        private void LoadFont()
        {
            foreach (FontFamily font in FontFamily.Families)
            {
                cbxFont.Items.Add(font.Name.ToString());
            }
        }
        
        //Pick color for text
        private void pColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                __color = colorDialog1.Color;
                pColor.BackColor = __color;
            }
        }

        //Set size for text
        private void cbxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                size = float.Parse(cbxSize.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex, "Xuất hiện lỗi!");
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
        
    }
}

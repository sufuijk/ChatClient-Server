using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    public partial class CreateServer : Form
    {
        public CreateServer()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if(txbIPServer.Text != "" || txbPortServer.Text != "")
                {
                    Server server = new Server(txbIPServer.Text, int.Parse(txbPortServer.Text));
                    server.Show();
                    this.Hide();
                }else
                {
                    MessageBox.Show("Nhập IP và Port để tạo server", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch 
            {
                MessageBox.Show("Không thể tạo server với IP này hoặc đã được sử dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAutoMakeIP_Click(object sender, EventArgs e)
        {
            txbIPServer.Text = GetIPLocal();
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
    }
}

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
using Server;

namespace Client
{
    public partial class SetInfo : Form
    {
        public SetInfo()
        {
            InitializeComponent();
        }
        public CUser obj = new CUser();
        
        private void button1_Click(object sender, EventArgs e)
        {
            //Set up info of user
            obj.IPServer = IPAddress.Parse(txbIPAddress.Text);
            obj.nickname = txbNickname.Text;
            obj.port = int.Parse(txbPortNumber.Text);
            //Tranfers user to new form
            
            Client maykhach = new Client(obj);
            maykhach.Show();
            this.Hide();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

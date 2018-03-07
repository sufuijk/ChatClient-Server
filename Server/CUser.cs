using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;

namespace Server
{
    [Serializable]
    public class CUser
    {
        public string nickname;
        public string message;
        public IPAddress IPServer;
        public int port;

        //Define text formatting
        public Color _color;
        public string fontFamily;
        public float size;


        public CUser()
        {

        }
        public CUser(string nickname, IPAddress ip)
        {
            this.nickname = nickname;
            this.IPServer = ip;
        }

        public void setMessage(string msg)
        {
            this.message = msg;
        }
        public string getMessage()
        {
            return this.message;
        }

    }
}

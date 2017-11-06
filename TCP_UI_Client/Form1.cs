using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP_UI_Client
{
    public partial class Client1 : Form
    {
        
        public Client1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //System.Net.IPAddress ip = new System.Net.IPAddress(long.Parse(txthost.Text));
            //server.Start(ip,Convert.ToInt32(txtPort))

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //if (Server.constantlyListen)
            //    Server.constantlyListen() = false;
        }

        private void textIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void textPort_TextChanged(object sender, EventArgs e)
        {

        }

        private void textMessage_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

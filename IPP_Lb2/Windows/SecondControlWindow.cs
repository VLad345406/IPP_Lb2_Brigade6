using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace IPP_Lb2.Windows
{
    public partial class SecondControlWindow : Form
    {
        private const string ServerIp = "127.0.0.1";
        
        private static void MakeRequest(string request)
        {
            try
            {
                var client = new TcpClient(ServerIp, 1111);
                var stream = client.GetStream();
                SendRequest(stream, request);
            }
            catch
            {
                MessageBox.Show("Error!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public SecondControlWindow()
        {
            InitializeComponent();
        }
        
        private void SecondControlWindow_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            MakeRequest("Up2");
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            MakeRequest("Down2");
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            MakeRequest("Left2");
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            MakeRequest("Right2");
        }
        
        private static void SendRequest(Stream stream, string request) 
        {
            var requestBuffer = Encoding.ASCII.GetBytes(request);
            stream.Write(requestBuffer, 0, requestBuffer.Length);
        }
    }
}
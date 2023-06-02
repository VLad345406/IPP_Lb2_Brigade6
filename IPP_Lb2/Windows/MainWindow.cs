using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPP_Lb2.Windows
{
    public  partial class MainWindow : Form
    {
        private async Task StartServer()
        {
            var listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 1111);
            listener.Start();

            while (true) {
                var client = await listener.AcceptTcpClientAsync();

                _ = HandleClientAsync(client);
            }
        }
        
        private async Task HandleClientAsync(TcpClient client) {
            var stream = client.GetStream();

            // Receive the request from the client
            var request = await FunctionReceive(stream);

            switch (request)
            {
                case "Up1":
                {
                    UpRectangle(pictureBox1);
                    break;
                }
                case "Down1":
                {
                    DownRectangle(pictureBox1);
                    break;
                }
                case "Left1":
                {
                    LeftRectangle(pictureBox1);
                    break;
                }
                case "Right1":
                {
                    RightRectangle(pictureBox1);
                    break;
                }

                case "Up2":
                {
                    UpRectangle(pictureBox2);
                    break;
                }
                case "Down2":
                {
                    DownRectangle(pictureBox2);
                    break;
                }
                case "Left2":
                {
                    LeftRectangle(pictureBox2);
                    break;
                }
                case "Right2":
                {
                    RightRectangle(pictureBox2);
                    break;
                }
            }
            client.Close();
        }
        
        private static async Task<string> FunctionReceive(NetworkStream stream)
        {
            var resultBuffer = new byte[1024];
            var resultBytesRead = await stream.ReadAsync(resultBuffer, 0, resultBuffer.Length);
            return Encoding.ASCII.GetString(resultBuffer, 0, resultBytesRead);
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private static void UpRectangle(Control pictureBox)
        {
            var getLocation = pictureBox.Location;
            var getX = getLocation.X;
            var getY = getLocation.Y;

            if (getY >= 10)
            {
                getY -= 10;
                pictureBox.Location = new Point(getX, getY);
            }
        }
        
        private void DownRectangle(Control pictureBox)
        {
            var getLocation = pictureBox.Location;
            var getX = getLocation.X;
            var getY = getLocation.Y;

            if (getY + 195 < this.Size.Height)
            {
                getY += 10;
                pictureBox.Location = new Point(getX, getY);
            }
        }
        
        private static void LeftRectangle(Control pictureBox)
        {
            var getLocation = pictureBox.Location;
            var getX = getLocation.X;
            var getY = getLocation.Y;

            if (getX >= 10)
            {
                getX -= 10;
                pictureBox.Location = new Point(getX, getY);
            }
        }
        
        private void RightRectangle(PictureBox pictureBox)
        {
            var getLocation = pictureBox.Location;
            var getX = getLocation.X;
            var getY = getLocation.Y;

            if (getX + 268 < this.Size.Width)
            {
                getX += 10;
                pictureBox.Location = new Point(getX, getY);
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            StartServer();
        }
    }
}
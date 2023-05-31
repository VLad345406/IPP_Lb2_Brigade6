using System;
using System.Windows.Forms;

namespace IPP_Lb2.Windows
{
    public partial class SecondControlWindow : Form
    {
        public SecondControlWindow()
        {
            InitializeComponent();
        }

        private void SecondControlWindow_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }
    }
}
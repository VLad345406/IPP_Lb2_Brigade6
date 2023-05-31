using System;
using System.Windows.Forms;

namespace IPP_Lb2.Windows
{
    public partial class FirstControlWindow : Form
    {
        public FirstControlWindow()
        {
            InitializeComponent();
        }

        private void FirstControlWindow_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }
    }
}
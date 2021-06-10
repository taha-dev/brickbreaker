using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Brick_Breaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_level1_Click(object sender, EventArgs e)
        {
            Level1 level1 = new Level1();
            level1.ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.MessageLoop)
                Application.Exit();
        }

        private void btn_level2_Click(object sender, EventArgs e)
        {

        }
    }
}
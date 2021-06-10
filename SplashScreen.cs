using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brick_Breaker
{
    public partial class SplashScreen : Form
    {
        Timer timer;
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Interval = 3000;
            timer.Start();
            timer.Tick += timer_Tick;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Hide();
        }
    }
}

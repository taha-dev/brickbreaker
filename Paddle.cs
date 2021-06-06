using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brick_Breaker
{
    class Paddle : PictureBox
    {
        private int _jump = 8;
        string _power;
        public Paddle(int x, int y, Color c)
        {
            // TODO: Complete member initialization
            Point temp = new Point(x, y);
            this.Location = temp;
            this.BackColor = c;
            this.Height = 20;
            this.Width = 100;
        }


        public int Jump
        {
            get
            {
                return _jump;
            }

            set
            {
                _jump = value;
            }
        }

        public string Power { get => _power; set => _power = value; }
        public void addPower(string power)
        {
            this.Power = power;
            this.Jump = 10;
        }
        public void removePower()
        {
            this.Power = null;
            this.Jump = 10;
        }
        public void Display(Graphics g)
        {
            g.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height));
        }
    }
}

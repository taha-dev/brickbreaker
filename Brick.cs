using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brick_Breaker
{
    class Brick : PictureBox
    {
        bool _state;
        int _strength;
        int _hits;
        string _power;
        public Brick(Point point, Color color, int strength, string power)
        {
            this.Width = 50;
            this.Height = 30;
            this.Location = point;
            this.BackColor = color;
            this._state = true;
            this._strength = strength;
            this._hits = 1;
            this._power = power;
        }

        public bool State { get => _state; set => _state = value; }
        public int Strength { get => _strength; set => _strength = value; }
        public string Power { get => _power; set => _power = value; }

        public void Display(Graphics g)
        {
            g.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height));
        }
        public void remove()
        {
            if (this._hits == this._strength)
            {
                this.BackColor = Color.Transparent;
                this.Visible = false;
                this.Enabled = false;
                this._state = false;
            }
            else
            {
                this._hits++;
            }
        }
        public void displayPower(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(this.Location.X, this.Location.Y, 20, 20));
        }

    }
}

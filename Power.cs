using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brick_Breaker
{
    class Power : PictureBox
    {
        string _type;
        int _dropspeed;

        public Power(int x, int y, int width, int height, string type,string img_path)
        {
            this.Location = new Point(x, y);
            this.Size = new Size(width, height);
            this._type = type;
            this.Image = Image.FromFile(img_path);
            this._dropspeed = 4;
        }

        public string Type { get => _type; set => _type = value; }
        public int Dropspeed { get => _dropspeed; set => _dropspeed = value; }
        public void DropPower()
        {
            Point p = this.Location;
            p.Y += Dropspeed;
            this.Location = p;
        }
        public void Display(Graphics g)
        {
            
            g.DrawImage(this.Image, this.Location.X, this.Location.Y);
            //g.FillEllipse(new SolidBrush(this.BackColor), new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height));
        }
    }
}

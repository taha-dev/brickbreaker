﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
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
        Power _power;
        SoundPlayer brickhit, brickbreak;
        public Brick(Point point, Color color, int strength, Power power=null)
        {
            this.Width = 50;
            this.Height = 30;
            this.Location = point;
            this.BackColor = color;
            this._state = true;
            this._strength = strength;
            this._hits = 1;
            this._power = power;
            brickhit = new SoundPlayer(@"..\..\Resources\brick_hit.wav");
            brickbreak = new SoundPlayer(@"..\..\Resources\brick_break.wav");
        }

        public bool State { get => _state; set => _state = value; }
        public int Strength { get => _strength; set => _strength = value; }
        internal Power BrickPower { get => this._power; set => this._power = value; }

        public void Display(Graphics g)
        {
            g.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height));
        }
        public bool remove()
        {
            this._hits++;
            if (this._hits == this._strength)
            {
                this.BackColor = Color.Transparent;
                this.Visible = false;
                this.Enabled = false;
                this._state = false;
                brickbreak.Play();
                return true;
            }
            brickhit.Play();
            if (this._hits == 2)
                this.BackColor = Color.Blue;
            return false;
        }
        public bool hasPower()
        {
            if (BrickPower != null)
                return true;
            return false;
        }

    }
}

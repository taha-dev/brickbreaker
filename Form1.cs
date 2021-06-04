﻿using System;
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
    public partial class Form1 : Form
    {
        Brick[,] bricks = new Brick[5, 11];
        Paddle paddle;
        Graphics graphics;
        Ball ball;
        Power power;
        bool UptoDown = false;
        public Form1()
        {
            InitializeComponent();
            graphics = Playarea.CreateGraphics();
            paddle = new Paddle(Playarea.Width / 2, Playarea.Height - 30, Color.Red);
            ball = new Ball(Playarea.Width / 2, Playarea.Height - 70);
            int x = 5, y = 5;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    bricks[i, j] = new Brick(new Point(x, y), Color.Black, 1, (i == 4)?"power":"nopower");
                    x += 60;
                }
                y += 40;
                x = 5;
            }
        }

        private void Playarea_Shown(object sender, EventArgs e)
        {
            foreach(Brick b in bricks)
            {
                b.Display(graphics);
            }
            paddle.Display(graphics);
            ball.Display(graphics);
            game_timer.Start();
        }

        /* private void Playarea_KeyPress(object sender, KeyPressEventArgs e)
           {
               int i = -1, j = -1;
               if(e.KeyChar >= '0' && e.KeyChar <= '4')
               {
                   i = 0;
                   j = Int16.Parse(e.KeyChar.ToString());
               }
               else if(e.KeyChar >= '5' && e.KeyChar <= '9')
               {
                   i = 1;
                   j = Int16.Parse(e.KeyChar.ToString()) - 5;
               }
               if(i > -1 && j > -1)
               {
                   bricks[i, j].remove();
                   Playarea.Invalidate();
               }
           }*/

        private void Playarea_Paint(object sender, PaintEventArgs e)
        {
            int x = 5, y = 5;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    bricks[i, j].Display(graphics);
                    x += 60;
                }
                y += 40;
                x = 5;
            }
            paddle.Display(graphics);
            ball.Display(graphics);
            if(power != null)
                power.Display(graphics);
        }
        private void CheckWallCollison()
        {
            if (ball.Bounds.IntersectsWith(rightWall.Bounds))
            {
                if (ball.Direction == BallDirection.DOWN_RIGHT)
                    ball.Direction = BallDirection.DOWN_LEFT;
                else if (ball.Direction == BallDirection.UP_RIGHT)
                    ball.Direction = BallDirection.UP_LEFT;
                else if (ball.Direction == BallDirection.RIGHT)
                {
                    if (UptoDown)
                        ball.Direction = BallDirection.DOWN_LEFT;
                    else
                        ball.Direction = BallDirection.UP_LEFT;
                }

            }

            else if (ball.Bounds.IntersectsWith(leftWall.Bounds))
            {
                if (ball.Direction == BallDirection.UP_LEFT)
                    ball.Direction = BallDirection.UP_RIGHT;
                else if (ball.Direction == BallDirection.DOWN_LEFT)
                    ball.Direction = BallDirection.DOWN_RIGHT;
                else if (ball.Direction == BallDirection.LEFT)
                {
                    if (UptoDown)
                        ball.Direction = BallDirection.DOWN_RIGHT;
                    else
                        ball.Direction = BallDirection.UP_RIGHT;
                }
            }
            else if (ball.Bounds.IntersectsWith(bottomWall.Bounds))
            {
                game_timer.Stop();
                MessageBox.Show("You Loose");

            }

        }
        private void CheckPaddleCollision()
        {
            if (ball.Bounds.IntersectsWith(paddle.Bounds) && UptoDown == true)
            {
                if (ball.Location.X > paddle.Location.X + (paddle.Width / 2 - 10) && ball.Location.X < paddle.Location.X + (paddle.Width / 2 + 10))
                    ball.Direction = BallDirection.UP;
                else if (ball.Location.X < paddle.Location.X + (paddle.Width / 2 - 10))
                {
                    if (ball.Direction == BallDirection.DOWN_RIGHT)
                        ball.Direction = BallDirection.UP_RIGHT;
                    else
                        ball.Direction = BallDirection.UP_LEFT;
                }
                else if (ball.Location.X > paddle.Location.X + (paddle.Width / 2 + 10))
                {
                    if (ball.Direction == BallDirection.DOWN_RIGHT)
                        ball.Direction = BallDirection.UP_RIGHT;
                    else
                        ball.Direction = BallDirection.UP_LEFT;
                }
                else if (ball.Location.Y >= paddle.Location.Y)
                {
                    if (ball.Location.X <= paddle.Location.X)
                        ball.Direction = BallDirection.LEFT;
                    else
                        ball.Direction = BallDirection.RIGHT;
                }
                else if (ball.Direction == BallDirection.DOWN_RIGHT)
                    ball.Direction = BallDirection.UP_RIGHT;
                else if (ball.Direction == BallDirection.DOWN_LEFT)
                    ball.Direction = BallDirection.UP_LEFT;
                else if (ball.Direction == BallDirection.UP_RIGHT)
                    ball.Direction = BallDirection.DOWN_RIGHT;
                else if (ball.Direction == BallDirection.UP_LEFT)
                    ball.Direction = BallDirection.DOWN_LEFT;
                UptoDown = false;

            }
        }
        private void CheckBrickCollision()
        {
            if (ball.Location.Y < 250)
            {
                foreach (Brick b in bricks)
                {
                    if (ball.Bounds.IntersectsWith(b.Bounds) && b.State && ball.Location.Y < 250)
                    {
                        if (ball.Location.X > b.Location.X + (b.Width / 2 - 10) && ball.Location.X < b.Location.X + (b.Width / 2 + 10))
                            ball.Direction = BallDirection.DOWN;
                        else if (ball.Location.X < b.Location.X + (b.Width / 2 - 10))
                        {
                            if (ball.Direction == BallDirection.UP_RIGHT)
                                ball.Direction = BallDirection.DOWN_RIGHT;
                            else
                                ball.Direction = BallDirection.DOWN_LEFT;
                        }
                        else if (ball.Location.X > b.Location.X + (b.Width / 2 + 10))
                        {
                            if (ball.Direction == BallDirection.UP_RIGHT)
                                ball.Direction = BallDirection.DOWN_RIGHT;
                            else
                                ball.Direction = BallDirection.DOWN_LEFT;
                        }
                        else if(ball.Location.Y >= b.Location.Y && ball.Location.Y < (b.Location.Y+b.Height))
                        {
                            if (ball.Location.X <= b.Location.X)
                                ball.Direction = BallDirection.LEFT;
                            else
                                ball.Direction = BallDirection.RIGHT;
                        }
                        else if (ball.Direction == BallDirection.UP_LEFT)
                            ball.Direction = BallDirection.DOWN_LEFT;
                        else if (ball.Direction == BallDirection.UP_RIGHT)
                            ball.Direction = BallDirection.DOWN_RIGHT;
                        UptoDown = true;
                        b.remove();
                        if (b.Power == "power")
                        {
                            power = new Power(b.Location.X, b.Location.Y, 20, 20, "power", @"..\..\Resources\power.png");
                            power.Display(graphics);
                        }
                        break;
                    }
                }
            }
        }
        private void game_timer_Tick(object sender, EventArgs e)
        {
            ball.MoveBall();
            CheckWallCollison();
            CheckPaddleCollision();
            CheckBrickCollision();
            Playarea.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                if (!paddle.Bounds.IntersectsWith(rightWall.Bounds))
                {
                    Point p = paddle.Location;
                    p.X += paddle.Jump;
                    paddle.Location = p;

                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (!paddle.Bounds.IntersectsWith(leftWall.Bounds))
                {
                    Point p = paddle.Location;
                    p.X -= paddle.Jump;
                    paddle.Location = p;

                }
            }
        }
    }
}
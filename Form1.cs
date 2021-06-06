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
        Brick[,] bricks = new Brick[5, 11];
        Paddle paddle;
        Graphics graphics;
        Ball ball;
        Power[,] power = new Power[5, 11];
        bool UptoDown = false;
        int timer = 0, bricks_count = 55;
        SoundPlayer hit_paddle_wall;
        public Form1()
        {
            InitializeComponent();
            graphics = Playarea.CreateGraphics();
            paddle = new Paddle(Playarea.Width / 2, Playarea.Height - 30, Color.Red);
            ball = new Ball(Playarea.Width / 2, Playarea.Height - 70);
            hit_paddle_wall = new SoundPlayer(@"..\..\Resources\paddle_wall_col.wav");
            int x = 5, y = 5;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (i == 4)
                    {
                        power[i,j] = new Power(x, y, 20, 20, "heart", @"..\..\Resources\speed.png");
                    }
                    else
                        power[i, j] = null;
                    bricks[i, j] = new Brick(new Point(x, y), Color.Black, 3, power[i, j]);
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

        private void Playarea_Paint(object sender, PaintEventArgs e)
        {
            int x = 5, y = 5;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    bricks[i, j].Display(graphics);
                    if (bricks[i, j].hasPower() && !bricks[i, j].State)
                        if(bricks[i,j].BrickPower.Image != null)
                        bricks[i, j].BrickPower.Display(graphics);
                    x += 60;
                }
                y += 40;
                x = 5;
            }
            paddle.Display(graphics);
            ball.Display(graphics);
        }
        private void CheckWallCollison()
        {
            if (ball.Bounds.IntersectsWith(rightWall.Bounds))
            {
                hit_paddle_wall.Play();
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
                hit_paddle_wall.Play();
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
            else if (ball.Bounds.IntersectsWith(topWall.Bounds))
            {
                hit_paddle_wall.Play();
                if (ball.Direction == BallDirection.UP)
                    ball.Direction = BallDirection.DOWN;
                else if (ball.Direction == BallDirection.UP_RIGHT)
                {
                    ball.Direction = BallDirection.DOWN_RIGHT;
                }
                else if (ball.Direction == BallDirection.UP_LEFT)
                {
                    ball.Direction = BallDirection.DOWN_LEFT;
                }
                UptoDown = true;
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
                hit_paddle_wall.Play();
                if (ball.Location.X > paddle.Location.X + (paddle.Width / 2 - 10) && ball.Location.X < paddle.Location.X + (paddle.Width / 2 + 10))
                    ball.Direction = BallDirection.UP;
                else if (ball.Direction == BallDirection.DOWN_RIGHT)
                        ball.Direction = BallDirection.UP_RIGHT;     
                else if(ball.Direction == BallDirection.DOWN_LEFT)
                    ball.Direction = BallDirection.UP_LEFT;
                else if(ball.Direction == BallDirection.DOWN)
                {
                    if (ball.Location.X <= paddle.Location.X + (paddle.Width / 2 - 10))
                        ball.Direction = BallDirection.UP_LEFT;
                    else
                        ball.Direction = BallDirection.UP_RIGHT;
                }
                UptoDown = false;

            }
        }
        private void CheckPowerCollision()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (bricks[i, j].hasPower() && !bricks[i, j].State)
                    {
                        if (power[i, j].Location.Y < bottomWall.Location.Y && power[i, j].Visible)
                        {
                            power[i, j].DropPower();
                            if (power[i, j].Bounds.IntersectsWith(paddle.Bounds))
                            {

                                power[i, j].Visible = false;
                                power[i, j].Image = null;
                                paddle.addPower(power[i, j].Type);
                            }
                            if (power[i, j].Bounds.IntersectsWith(bottomWall.Bounds))
                            {
                                power[i, j].Visible = false;
                                power[i, j].Image = null;
                            }
                        }
                    }
                }
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
                        if (ball.Location.Y >= (b.Location.Y + b.Height) - 5)
                        {
                            if (ball.Direction == BallDirection.UP)
                                ball.Direction = BallDirection.DOWN;
                            else if (ball.Direction == BallDirection.UP_RIGHT)
                            {
                                ball.Direction = BallDirection.DOWN_RIGHT;
                            }
                            else if (ball.Direction == BallDirection.UP_LEFT)
                            {
                                ball.Direction = BallDirection.DOWN_LEFT;
                            }
                        }
                        else if(ball.Location.Y < (b.Location.Y + b.Height) && ball.Location.Y > b.Location.Y)
                        {
                            if (ball.Direction == BallDirection.UP_RIGHT)
                                ball.Direction = BallDirection.UP_LEFT;
                            else if (ball.Direction == BallDirection.DOWN_RIGHT)
                                ball.Direction = BallDirection.DOWN_LEFT;
                            else if (ball.Direction == BallDirection.UP_LEFT)
                                ball.Direction = BallDirection.UP_RIGHT;
                            else if (ball.Direction == BallDirection.DOWN_LEFT)
                                ball.Direction = BallDirection.DOWN_RIGHT;
                        }
                        else if (ball.Location.Y < b.Location.Y - 5)
                        {
                            if (ball.Direction == BallDirection.DOWN_RIGHT)
                                ball.Direction = BallDirection.UP_RIGHT;
                            else if (ball.Direction == BallDirection.DOWN_LEFT)
                                ball.Direction = BallDirection.UP_LEFT;
                        }
                        UptoDown = true;
                        if (b.remove() && b.hasPower())
                        {
                            bricks_count--;
                            b.BrickPower.Display(graphics);
                        }
                        
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
            CheckPowerCollision();
            if(timer >= 0 && paddle.Power != null)
            {
                timer++;
            }
            if(timer == 100)
            {
                timer = 0;
                paddle.removePower();
            }
            if(bricks_count < 1)
            {
                game_timer.Stop();
                MessageBox.Show("You Won");
            }
            Playarea.Invalidate();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'p' || e.KeyChar == 'P')
                game_timer.Stop();
            else if ((e.KeyChar == 'r' || e.KeyChar == 'R') && bricks_count > 0)
                game_timer.Start();
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
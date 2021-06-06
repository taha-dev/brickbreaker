
namespace Brick_Breaker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Playarea = new System.Windows.Forms.Panel();
            this.bottomWall = new System.Windows.Forms.Panel();
            this.topWall = new System.Windows.Forms.Panel();
            this.rightWall = new System.Windows.Forms.Panel();
            this.leftWall = new System.Windows.Forms.Panel();
            this.game_timer = new System.Windows.Forms.Timer(this.components);
            this.Playarea.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(140, 450);
            this.panel1.TabIndex = 0;
            // 
            // Playarea
            // 
            this.Playarea.Controls.Add(this.bottomWall);
            this.Playarea.Controls.Add(this.topWall);
            this.Playarea.Controls.Add(this.rightWall);
            this.Playarea.Controls.Add(this.leftWall);
            this.Playarea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Playarea.Location = new System.Drawing.Point(140, 0);
            this.Playarea.Name = "Playarea";
            this.Playarea.Size = new System.Drawing.Size(660, 450);
            this.Playarea.TabIndex = 1;
            this.Playarea.Paint += new System.Windows.Forms.PaintEventHandler(this.Playarea_Paint);
            // 
            // bottomWall
            // 
            this.bottomWall.BackColor = System.Drawing.Color.Transparent;
            this.bottomWall.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomWall.Location = new System.Drawing.Point(1, 449);
            this.bottomWall.Name = "bottomWall";
            this.bottomWall.Size = new System.Drawing.Size(658, 1);
            this.bottomWall.TabIndex = 3;
            // 
            // topWall
            // 
            this.topWall.BackColor = System.Drawing.Color.Transparent;
            this.topWall.Dock = System.Windows.Forms.DockStyle.Top;
            this.topWall.Location = new System.Drawing.Point(1, 0);
            this.topWall.Name = "topWall";
            this.topWall.Size = new System.Drawing.Size(658, 1);
            this.topWall.TabIndex = 2;
            // 
            // rightWall
            // 
            this.rightWall.BackColor = System.Drawing.Color.Transparent;
            this.rightWall.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightWall.Location = new System.Drawing.Point(659, 0);
            this.rightWall.Name = "rightWall";
            this.rightWall.Size = new System.Drawing.Size(1, 450);
            this.rightWall.TabIndex = 1;
            // 
            // leftWall
            // 
            this.leftWall.BackColor = System.Drawing.Color.Transparent;
            this.leftWall.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftWall.Location = new System.Drawing.Point(0, 0);
            this.leftWall.Name = "leftWall";
            this.leftWall.Size = new System.Drawing.Size(1, 450);
            this.leftWall.TabIndex = 0;
            // 
            // game_timer
            // 
            this.game_timer.Enabled = true;
            this.game_timer.Interval = 50;
            this.game_timer.Tick += new System.EventHandler(this.game_timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Playarea);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Brick Breaker";
            this.Shown += new System.EventHandler(this.Playarea_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.Playarea.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel Playarea;
        private System.Windows.Forms.Timer game_timer;
        private System.Windows.Forms.Panel leftWall;
        private System.Windows.Forms.Panel rightWall;
        private System.Windows.Forms.Panel topWall;
        private System.Windows.Forms.Panel bottomWall;
    }
}


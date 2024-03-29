﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        Random r;
        int score = 0;
        int currscore = 0;
        double lvl = 1;
        int highscore1 = 0;
        int highscore2 = 0;
        int highscore3 = 0;
        bool flag;
        int timeout;
        float clicks = 0;
        float success = 0;
        float percentage = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 username = new Form2();
           
            DialogResult ds = username.ShowDialog(this);
            if (ds == DialogResult.OK)
            {
                user_label.Text += username.user_tb.Text;
            }
            else if (ds == DialogResult.Cancel)
            {
                this.Dispose();   
            }
            username.Dispose();

            r = new Random();

            //Panel1 adjusts its dimensions according to Form1.
            panel1.Location = new Point(0, panel1.Location.Y);
            panel1.Width = this.ClientSize.Width;
            panel1.Height = this.ClientSize.Height - panel1.Location.Y;

            //Default level is easy.
            levels.SelectedIndex = 0;

            //Default time of game is 1 minute.
            times.SelectedIndex = 0;
        }
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                score += 20;
                label2.Text = score.ToString();
                
                success =success+ 1;
                clicks = clicks + 1;
                percentage = (success / clicks) * 100;
                label8.Text =percentage.ToString("n2") + "%";
            }
            else
            {
                MessageBox.Show("Hit the 'Play!' button!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flag = true;
            timer1.Enabled = true;
            timer2.Enabled = true;

            clicks = 0;
            percentage = 0;
            success = 0;

            label8.Text = "0%";

            //Level set.For each level the speed of frog changes.
            //Check up to see on which level are we and set up the highscore of each level.
            switch (levels.Text)
            {
                case "Easy":
                    lvl = 1;

                    if (highscore1 <= currscore) highscore1 = currscore;
                    label6.Text = highscore1.ToString();

                    break;
                case "Medium":
                    lvl = 0.8;

                    if (highscore2 <= currscore) highscore2 = currscore;
                    label6.Text = highscore2.ToString();

                    break;
                case "Hard":
                    lvl = 0.6;

                    if (highscore3 <= currscore) highscore3 = currscore;
                    label6.Text = highscore3.ToString();

                    break;
            }


            timeout = int.Parse(times.Text);
            timeout = timeout * 60;


            timer1.Interval = (int)(1000 * lvl);
            //timer2.Interval = Convert.ToInt32(times.Text) * 60000;

            times.Enabled = false;
            levels.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Game pauses everytime window minimizes.
            if (this.WindowState == FormWindowState.Minimized) return;

            Point p1 = new Point(r.Next(0, this.panel1.Width - pictureBox1.Width), r.Next(0, this.panel1.Height - pictureBox1.Height)); //me to this. pairnw to witdh kai height ths formas.alliws pairnei tou button1.
            pictureBox1.Location = p1;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) return;

            if (timeout == -1)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                MessageBox.Show("Your score is: " + label2.Text);
                currscore = score; //one var to store the current score of each level  
                score = 0;
                label2.Text = score.ToString();
                flag = false;

                levels.Enabled = true;
                times.Enabled = true;
            }
            else
            {
                label7.Text = timeout.ToString();
                timeout = timeout - 1;
            }

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //Everytime Form1 changes dimensions ,panel1 also changes.
            panel1.Height = this.ClientSize.Height - panel1.Location.Y;
            panel1.Width = this.ClientSize.Width;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {

            clicks =clicks+ 1;
            percentage = (success / clicks)*100;
            
            label8.Text =percentage.ToString("n2") + "%";
        }
    }
}

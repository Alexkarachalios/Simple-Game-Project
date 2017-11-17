using System;
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
        double lvl = 1;
        bool flag;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            r = new Random();

            //Ekana to panel1 (pista gia ton batraxo) na exei megethos olhs ths formas.
            panel1.Location = new Point(0, panel1.Location.Y);
            panel1.Width = this.ClientSize.Width;
            panel1.Height = this.ClientSize.Height - panel1.Location.Y;

            //Default level einai to easy.
            levels.SelectedIndex = 0;

            //Default xronos paixnidiou einai 1 lepto.
            times.SelectedIndex = 0;
        }
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                score += 20;
                label2.Text = score.ToString();
                
            }else
            {
                MessageBox.Show("Hit the 'Play!' button!");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flag = true;
            timer1.Enabled = true;
            timer2.Enabled = true;

            //Epilogh level. Gia kathe level alazei o xronos akhnisias tou batraxou.
            switch (levels.Text)
            {
                case "Easy":
                    lvl = 1;
                    break;
                case "Medium":
                    lvl = 0.8;
                    break;
                case "Hard":
                    lvl = 0.6;
                    break;
            }

            

            timer1.Interval = (int)(1000 * lvl);
            timer2.Interval = Convert.ToInt32(times.Text) * 60000;

            times.Enabled = false;
            levels.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point p1 = new Point(r.Next(0, this.panel1.Width - pictureBox1.Width), r.Next(0, this.panel1.Height - pictureBox1.Height)); //me to this. pairnw to witdh kai height ths formas.alliws pairnei tou button1.
            pictureBox1.Location = p1;
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            MessageBox.Show("Your score is: " + label2.Text);
            score = 0;
            label2.Text = score.ToString();
            flag = false;

            levels.Enabled = true;
            times.Enabled = true;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            /*Kathe fora pou alazei to megethos ths 
             * alazei kai to megethos tis pistas.*/
            panel1.Height = this.ClientSize.Height - panel1.Location.Y;
            panel1.Width = this.ClientSize.Width;
        }
    }
}

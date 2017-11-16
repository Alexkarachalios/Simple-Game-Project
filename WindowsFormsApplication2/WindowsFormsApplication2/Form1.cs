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
        bool flag;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
              
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            r = new Random();
            
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
            



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            Point p1 = new Point(r.Next(0, this.panel1.Width - pictureBox1.Width), r.Next(0, this.panel1.Height - pictureBox1.Height)); //me to this. pairnw to witdh kai height ths formas.alliws pairnei tou button1.
            pictureBox1.Location = p1;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
            timer1.Enabled = false;
            timer2.Enabled = false;
            MessageBox.Show("Your score is: " + label2.Text);
            score = 0;
            label2.Text = score.ToString();
            flag = false;




        }

       
        

        
            
        
    }
}

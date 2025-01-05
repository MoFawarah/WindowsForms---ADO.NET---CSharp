using FirstWinFormsProject.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstWinFormsProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
        }

        //reset
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text = "";
            textBox1.Enabled = true; 
            textBox1.Visible = true;
            this.Text = "Weeeeeee";
            button2.Visible = false;
            button3.Enabled = false;

        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            textBox2.Enabled = true;
            textBox2.Width = 200;
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            textBox2.Text = textBox1.Text;
          
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.download;
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.Mohammad_Fawareh;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\m.fawareh\Desktop\Per Stuff\th.jpeg");
        }
    }
}

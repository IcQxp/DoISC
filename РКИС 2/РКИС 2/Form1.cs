using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace РКИС_2
{
    public partial class Form1 : Form
    {
        
        private int counter = 0;
        private Color[] colors = new Color[]
        {
            Color.Red,
            Color.Orange,
            Color.Yellow,
            Color.Green,
            Color.Aquamarine,
            Color.Blue,
            Color.Magenta,
            Color.White,
            Color.Gray,
            Color.Black
        };

        public Form1()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "*****";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
            textBox1.Text = "+++++";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.BackColor = colors[counter];
            counter++;
            if (counter == colors.Length) { counter = 0; }
        }
    }
}

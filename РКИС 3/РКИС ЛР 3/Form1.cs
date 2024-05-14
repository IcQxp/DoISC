using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace РКИС_ЛР_3
{
    public partial class Form1 : Form
    {
        private int ball = 0;
        private int ocenka =0;
        private bool firstPop = false;
        public Form1()
        {
            InitializeComponent();



            vScrollBar1.Dock = DockStyle.Right;
            vScrollBar1.Minimum = 0;
            vScrollBar1.Maximum = panel1.Height - this.Height;


            vScrollBar1.SmallChange = panel1.Height / 10;


            vScrollBar1.ValueChanged += (sender, e) =>
            {
                if (vScrollBar1.Value < vScrollBar1.Minimum)
                {
                    vScrollBar1.Value = vScrollBar1.Minimum;
                }
                else if (vScrollBar1.Value > vScrollBar1.Maximum)
                {
                    vScrollBar1.Value = vScrollBar1.Maximum;
                }

                panel1.Top = -vScrollBar1.Value;
            };

            panel1.MouseWheel += panel1_MouseWheel;
        }

        private void panel1_MouseWheel(object sender, MouseEventArgs e)
        {
            //if (vScrollBar1.Value>=10)
            //if (vScrollBar1.Value >= (e.Delta / SystemInformation.MouseWheelScrollDelta * vScrollBar1.SmallChange) && vScrollBar1.Value - e.Delta / SystemInformation.MouseWheelScrollDelta * vScrollBar1.SmallChange < vScrollBar1.Maximum)
            //    vScrollBar1.Value -= e.Delta / SystemInformation.MouseWheelScrollDelta * vScrollBar1.SmallChange;
            int vector = e.Delta / SystemInformation.MouseWheelScrollDelta * vScrollBar1.SmallChange;
            if (vScrollBar1.Minimum + 3 * vector <= vScrollBar1.Value && vScrollBar1.Value <= vScrollBar1.Maximum + 3 * vector)
                vScrollBar1.Value -= 3 * vector;
            else if (vScrollBar1.Minimum + vector / 5 <= vScrollBar1.Value && vScrollBar1.Value <= vScrollBar1.Maximum + vector / 5)
                vScrollBar1.Value -= vector / 5;


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {//1
            int LocationStartY = 10;
            groupBox2.Height = 160;
            //2
            LocationStartY += groupBox2.Height;
            groupBox1.Height = 160;
            groupBox1.Location = new Point(10, LocationStartY);
            //3
            LocationStartY += groupBox1.Height;
            groupBox3.Height = 160;
            groupBox3.Location = new Point(10, LocationStartY);
            //4
            LocationStartY += groupBox3.Height;
            groupBox4.Height = 70;
            groupBox4.Location = new Point(10, LocationStartY);
            //5
            LocationStartY += groupBox4.Height;
            groupBox5.Height = 160;
            groupBox5.Location = new Point(10, LocationStartY);
            //6
            LocationStartY += groupBox5.Height;
            groupBox6.Height = 100;
            groupBox6.Location = new Point(10, LocationStartY);
            //7
            LocationStartY += groupBox6.Height;
            groupBox7.Height = 140;
            groupBox7.Location = new Point(10, LocationStartY);
            //8
            LocationStartY += groupBox7.Height;
            groupBox8.Height = 160;
            groupBox8.Location = new Point(10, LocationStartY);

            //9
            LocationStartY += groupBox8.Height;
            groupBox9.Height = 160;
            groupBox9.Location = new Point(10, LocationStartY);
            //10

            LocationStartY += groupBox9.Height;
            groupBox10.Height = 160;
            groupBox10.Location = new Point(10, LocationStartY);
            //otvet
            LocationStartY += groupBox10.Height;
            button1.Height = 55;
            button1.Location = new Point(10, LocationStartY);

            //rez
            button2.Height = 55;
            button2.Location = new Point(135, LocationStartY);
        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { if (!firstPop) { 
            ball = 0;
            if (truebutton1.Checked)
                ball++;
            if (truebutton2.Checked)
                ball++;
            if (checkBox2.Checked && checkBox3.Checked && checkBox4.Checked)
                ball++;
            if (textBox1.Text.ToLower().Trim() == "операционная система")
                ball++;
            if (truebutton3.Checked)
                ball++;
            if (textBox2.Text.ToLower().Trim() == "ресурсами")
                ball++;
            if (radioButton15.Checked)
                ball++;
            if (checkBox6.Checked && checkBox7.Checked && checkBox8.Checked)
                ball++;
            if (truebutton5.Checked)
                ball++;
            if (truebutton6.Checked)
                ball++;
            ocenka = (ball + 1) / 2;
            switch (ocenka)
            {
                case 3:
                    MessageBox.Show("Оценка: удовлетворительно\nБаллов:" + ball);
                    break;
                case 4:
                    MessageBox.Show("Оценка: хорошо\nБаллов:" + ball);
                    break;
                case 5:
                    MessageBox.Show("Оценка: отлично\nБаллов:" + ball);
                    break;
                default:
                    MessageBox.Show("Оценка: неудовлетворительно\nБаллов:" + ball);

                    break;
            }
            button2.Visible = true;
            button2.Enabled = true;
                firstPop = true;
            }else
            {
                switch (ocenka)
                {
                    case 3:
                        MessageBox.Show("Ваша первая оценка: удовлетворительно\nБаллов:" + ball);
                        break;
                    case 4:
                        MessageBox.Show("Ваша первая оценка: хорошо\nБаллов:" + ball);
                        break;
                    case 5:
                        MessageBox.Show("Ваша первая оценка: отлично\nБаллов:" + ball);
                        break;
                    default:
                        MessageBox.Show("Ваша первая оценка: неудовлетворительно\nБаллов:" + ball);

                        break;
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Посмотреть правильные ответы")
            {
                truebutton1.BackColor = Color.LightGreen;
                truebutton2.BackColor = Color.LightGreen;
                checkBox2.BackColor = Color.LightGreen;
                checkBox3.BackColor = Color.LightGreen;
                checkBox4.BackColor = Color.LightGreen;
                textBox1.Text = "операционная система";
                textBox1.BackColor = Color.LightGreen;
                truebutton3.BackColor = Color.LightGreen;
                textBox2.Text = "ресурсами";
                textBox2.BackColor = Color.LightGreen;
                radioButton15.BackColor = Color.LightGreen;
                checkBox6.BackColor = Color.LightGreen;
                checkBox7.BackColor = Color.LightGreen;
                checkBox8.BackColor = Color.LightGreen;
                truebutton5.BackColor = Color.LightGreen;
                truebutton6.BackColor = Color.LightGreen;
                button2.Text = "Скрыть правильные ответы";
            }
            else
            {
                truebutton1.BackColor = SystemColors.ActiveCaption;
                truebutton2.BackColor = SystemColors.ActiveCaption;
                checkBox2.BackColor = SystemColors.ActiveCaption;
                checkBox3.BackColor = SystemColors.ActiveCaption; 
                checkBox4.BackColor = SystemColors.ActiveCaption;
                textBox1.Text = "";
                textBox1.BackColor = SystemColors.ActiveCaption;
                truebutton3.BackColor = SystemColors.ActiveCaption;
                textBox2.Text = "";
                textBox2.BackColor = SystemColors.ActiveCaption;
                radioButton15.BackColor = SystemColors.ActiveCaption;
                checkBox6.BackColor = SystemColors.ActiveCaption;
                checkBox7.BackColor = SystemColors.ActiveCaption;
                checkBox8.BackColor = SystemColors.ActiveCaption;
                truebutton5.BackColor = SystemColors.ActiveCaption;
                truebutton6.BackColor = SystemColors.ActiveCaption;
                button2.Text = "Посмотреть правильные ответы";
            }
        }
    }
}

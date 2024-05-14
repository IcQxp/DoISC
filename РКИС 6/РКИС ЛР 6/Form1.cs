using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace РКИС_ЛР_6
{

    public partial class Form1 : Form
    {
        private int hours, minutes, seconds;
        private bool paused = false;

        private int b_hours = 0, b_minutes = 0;
        private bool waiting_budilnik = false;

        private void button1_Click(object sender, EventArgs e)//Кнопка старт
        {
            if (!paused)                                            //если не пауза, то
            {
                if (maskedTextBox1.Text == "") hours = 0;           // textbox => hours
                else hours = Convert.ToInt32(maskedTextBox1.Text);

                if (maskedTextBox2.Text == "") minutes = 0;         // textbox => minutes
                else minutes = Convert.ToInt32(maskedTextBox2.Text);

                if (maskedTextBox3.Text == "") seconds = 0;         // textbox => seconds
                else seconds = Convert.ToInt32(maskedTextBox3.Text);

                if (minutes == 0 && seconds == 0 && hours == 0) MessageBox.Show("Введите какое-то значение"); //Если всё по 0, то сообщение
                else 
                {
                    while (seconds > 60)    // 60 seconds => 1 minute
                    {
                        minutes++;
                        seconds -= 60;
                    }
                    while (minutes > 60)    // 60 minutes => 1 hour
                    {
                        hours++;
                        minutes -= 60;
                    }
                    LabelShow();
                    first_second_buttons_enable_and_timer(false, true,true);

                }
            }
            else       
            {           
                LabelShow();
                first_second_buttons_enable_and_timer(false, true,true);
            }
        }

        private void LabelShow()
        {
            label1.Text = hours.ToString();     
            if (minutes < 10) label3.Text = "0" + minutes.ToString();
            else label3.Text = minutes.ToString();
            if (seconds < 10) label5.Text = "0" + seconds.ToString();
            else label5.Text = seconds.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            seconds--;
            if (seconds == -1)
            {
                minutes--;
                seconds = 59;
            }
            if (minutes == -1)
            {
                hours--;
                minutes = 59;
            }
            LabelShow();

            if (seconds == 0 && hours == 0 && minutes == 0)
            {
                first_second_buttons_enable_and_timer(true, false, false);
                paused = false;
                TimesUp("ТАЙМЕР");
            }
        }

        private void TimesUp(string v)
        {
            System.IO.Stream str = Properties.Resources.videoplayback;
            SoundPlayer sp = new SoundPlayer(str);
            sp.Play();
            MessageBox.Show(v);
            sp.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Text = "Продолжить";
            paused = true;
            first_second_buttons_enable_and_timer(true,false,false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "00";
            label3.Text = "00";
            label5.Text = "00";
            minutes = 0;
            hours = 0;
            seconds = 0;
            button1.Text = "Старт";
            paused = false;
            first_second_buttons_enable_and_timer(true,false,false);
        }

        private void first_second_buttons_enable_and_timer(bool first,bool second,bool start)
        {
            button1.Enabled = first;
            button2.Enabled = second;
            if (start)  timer2.Start();
            else        timer2.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToLongTimeString().ToString();
            int h = DateTime.Now.Hour;
            int m = DateTime.Now.Minute;
            toolStripStatusLabel2.Text = DateTime.Now.ToLongDateString();
            toolStripStatusLabel3.Text = time;
            label9.Text = time;
            if (waiting_budilnik)
                if (h == b_hours && m == b_minutes)
                {
                    waiting_budilnik = false;
                    button4.Enabled = true;
                    button5.Enabled = false;
                    TimesUp("БУДИЛЬНИК");
                }
        }
               
        private void button4_Click(object sender, EventArgs e)
        {
            int i = maskedTextBox4.Text.Length;
            string minutes_b = "";
            string hours_b = maskedTextBox4.Text.Substring(0, 2);
            if (!(i == 3 && hours_b == "  "))
            { 
                switch (i) 
                {
                    case 3: minutes_b = "00"; break;
                    case 4: minutes_b = "0" + maskedTextBox4.Text.Substring(3, 1); break;
                    case 5:
                        minutes_b = maskedTextBox4.Text.Substring(3, 2);
                        if (minutes_b.Substring(0, 1) == " ")
                            minutes_b = "0" + minutes_b.Substring(1, 1); break;
                }
                if (hours_b == "  ")
                    hours_b = "0";
                b_hours = Convert.ToInt32(hours_b);
                b_minutes = Convert.ToInt32(minutes_b);
                waiting_budilnik = true;
                button4.Enabled = false;
                button5.Enabled = true;
            }
            else MessageBox.Show("Введите значение");
        }

        public Form1()
        {
            InitializeComponent();
            maskedTextBox1.HidePromptOnLeave = true;
            maskedTextBox2.HidePromptOnLeave = true;
            maskedTextBox3.HidePromptOnLeave = true;
            maskedTextBox4.HidePromptOnLeave = true;
            button2.Enabled = false;
            button5.Enabled = false;
            timer1.Start();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace РКИС_ЛР_5
{
    public partial class Form1 : Form
    {
        private int player = 1;                                 // крестик
        private int[,] score = new int[3,3] {   { 0, 0, 0 }, 
                                                { 0, 0, 0 },    // поле для очков
                                                { 0, 0, 0 } };
        private int free_space_count = 9;                       // кол-во свободных кнопок
        private bool win_factor = false;                        // победа или нет
        private Button[,] place;                                // массив кнопок
        

        public Form1()
        {
            InitializeComponent();
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;  // список для комбобокса
            comboBox1.Text = comboBox1.Items[0].ToString();             // комбобокс присваивает дефолтное значение
            place = new Button[3,3] {   {button1, button2,button3},
                                        { button4, button5,button6 },
                                        { button7, button8,button9 } };
            label1.Text = "Ход Х-игрока";
        }

        private void button10_Click(object sender, EventArgs e) // кнопка новой игры
        {
            win_factor = false;                                 // нет победы
            if (comboBox1.Text == "Крестик")                    // определение игрока
            {
                player = 1;
            }
            else
            {
                player = -1;
            }
            unlock_button(true);                                // отчистка кнопок
            free_space_count = 9;                               // обновление кол-ва свободных кнопок
            if (player==1)
            {
                label1.Text = "Ход Х-игрока";
            }
            else
            {
                label1.Text = "Ход О-игрока";
            }
        }

        private void button1_Click(object sender, EventArgs e)  // кнопка-ход
        {
            Button B = (Button)sender;              // Апкаст кнопки
            int[] coor = new int[2];                // координаты 
            for (int y = 0; y < 3; y++)             
            {
                for (int x = 0; x < 3; x++)
                {
                    if (B == place[y, x])
                    {
                        coor[0] = x;
                        coor[1] = y;
                        if (player==1)
                        {
                            score[y, x] = 1;
                        }
                        else
                        {
                            score[y, x] = -1;
                        }
                    }

                }
            }

            if (player == 1)
            {
                B.Text = "X";
                player = -1;

                label1.Text = "Ход О-игрока";
            }
            else
            {
                B.Text = "O";
                player = 1;

                label1.Text = "Ход Х-игрока";
            }
            B.Enabled = false;

            //for (int y=0;y<3;y++)
            //{
            //    for (int x = 0; x < 3; x++)
            //    {
            //        Console.Write("\t"+score[y,x]);
            //    }
            //    Console.WriteLine();
            //}

            //Условия победы
            int win_line_1 = score[0, 0] + score[0, 1] + score[0, 2];
            if (win_line_1==3|| win_line_1 == -3)
            {
                who_win(win_line_1);
            }
            int win_line_2 = score[1, 0] + score[1, 1] + score[1, 2];
            if (win_line_2 == 3 || win_line_2 == -3)
            {
                who_win(win_line_2);
            }
            int win_line_3 = score[2, 0] + score[2, 1] + score[2, 2];
            if (win_line_3 == 3 || win_line_3 == -3)
            {
                who_win(win_line_3);
            }
            int win_line_4 = score[0, 0] + score[1, 0] + score[2,0 ];
            if (win_line_4 == 3 || win_line_4 == -3)
            {
                who_win(win_line_4);
            }
            int win_line_5 = score[0, 1] + score[1, 1] + score[2, 1];
            if (win_line_5 == 3 || win_line_5 == -3)
            {
                who_win(win_line_5);
            }
            int win_line_6 = score[0, 2] + score[1, 2] + score[2, 2];
            if (win_line_6 == 3 || win_line_6 == -3)
            {
                who_win(win_line_6);
            }
            int win_line_7 = score[0, 0] + score[1, 1] + score[2, 2];
            if (win_line_7 == 3 || win_line_7 == -3)
            {
                who_win(win_line_7);
            }
            int win_line_8 = score[0, 2] + score[1, 1] + score[2, 0];
            if (win_line_8 == 3 || win_line_8 == -3)
            {
                who_win(win_line_8);
            }

            free_space_count--;
            if (win_factor)
            {
                unlock_button(false);
            }
            if (free_space_count == 0 && !win_factor)
            {
                MessageBox.Show("Ничья");
                unlock_button(true);

            }
        }

        private void who_win(int winners_score)
        {
            if (!win_factor)
            {
                if (winners_score == 3)
                {
                    MessageBox.Show("Победил Крестик");
                }
                else
                {
                    MessageBox.Show("Победил Нолик");
                }
            }
            win_factor = true;
        }

        private void unlock_button(bool unlock)
        {
            if (!unlock) {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        place[i, j].Enabled = false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        place[i, j].Enabled = true;
                        place[i, j].Text = "";
                        score[i, j] = 0;
                    }
                }
                if (comboBox1.Text == "Крестик")
                {
                    player = 1;
                    label1.Text = "Ход Х-игрока";
                }
                else
                {
                    player = -1;
                    label1.Text = "Ход О-игрока";
                }
                free_space_count = 9;
            }
        }
    }
}

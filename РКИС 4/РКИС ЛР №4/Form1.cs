using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace РКИС_ЛР__4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//лкм
            {
                Control newControl;
                if (new Random().Next(2) == 0)
                {
                    newControl = new Button();
                    (newControl as Button).Text = "Button";
                }
                else
                {
                    newControl = new TextBox();
                }
                newControl.Location = this.PointToClient(Cursor.Position);
                this.Controls.Add(newControl);
            }
            else if (e.Button == MouseButtons.Right)//пкм
            {
                //foreach (Control control in this.Controls)
                //{
                //    if (control.GetType() == typeof(Button) || control.GetType() == typeof(TextBox))
                //    {
                //        this.Controls.Remove(control);
                //    }
                //}
                for (int i = this.Controls.Count - 1; i >= 0; i--)
                {
                    Control control = this.Controls[i];
                  //if (control.GetType() == typeof(Button) || control.GetType() == typeof(TextBox))
                    if (control is Button || control is TextBox)
                    {
                        this.Controls.RemoveAt(i);
                    }
                }
            }
        }
    }
}

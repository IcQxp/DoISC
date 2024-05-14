using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace РКИС_ЛР__8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Window1 win1 = new Window1

            {
                Title = "Your Window Title",
                Width = 200,
                Height = 200
            };
   
            win1.Show();
            Window2 win2 = new Window2
                {
                    Title = "Your Window Title",
                    Width = 300,
                    Height = 300
                };
            win2.Show();
        }
    }
}

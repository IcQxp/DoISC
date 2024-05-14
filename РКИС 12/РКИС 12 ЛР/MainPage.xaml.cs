using System;
using System.Windows.Controls;

namespace РКИС_12_ЛР
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            ShowAppropriateText();
        }
        private void ShowAppropriateText()
        {
            DateTime currentTime = DateTime.Now;
            string textToShow = "";

            if (currentTime.TimeOfDay >= new TimeSpan(9, 0, 0) && currentTime.TimeOfDay <= new TimeSpan(11, 0, 0))
                textToShow = "Доброе утро";
            else if (currentTime.TimeOfDay > new TimeSpan(11, 0, 0) && currentTime.TimeOfDay <= new TimeSpan(18, 0, 0))
                textToShow = "Добрый день";
            else
                textToShow = "Добрый вечер";

            TimeText.Text = textToShow;
        }
    }
}

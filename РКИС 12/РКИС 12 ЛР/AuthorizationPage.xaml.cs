using System;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace РКИС_12_ЛР
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        Random _random = new Random();
        string stringCaptcha;
        public AuthorizationPage()
        {
            InitializeComponent();
            UpdateCaptcha();
        }

        private void UpdateCaptcha()
        {
            stringCaptcha = " ";
            SymnolsPanel.Children.Clear();
            NoiseCanvas.Children.Clear();
            GenerateSymbols(4);
            GenerateNoise(_random.Next(10, 15));
        }
        private void GenerateNoise(int volumeNoise)
        {
            for (int i = 0;i< volumeNoise;i++)
            {
                Border border = new Border();
                border.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb((byte)_random.Next(50, 150),
                    (byte)_random.Next(0, 256),
                    (byte)_random.Next(0, 256),
                    (byte)_random.Next(0, 256)));
                border.Height = _random.Next(2, 10);
                border.Width = _random.Next(20, 100);
                border.RenderTransform = new RotateTransform(_random.Next(0, 90));

                NoiseCanvas.Children.Add(border);
                Canvas.SetLeft(border, _random.Next(0, 200));
                Canvas.SetTop(border, _random.Next(0, 70));

                Ellipse ellipse = new Ellipse();
                ellipse.Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(
                    (byte)_random.Next(50,150),
                    (byte)_random.Next(0, 256),
                    (byte)_random.Next(0, 256),
                    (byte)_random.Next(0, 256))
                    );
            }

        }
        private void GenerateSymbols(int count)
        {
            string alphabet = "WERPASFHKXVBM2345678";
            for (int i = 0; i < count; i++)
            {
                string symbol = alphabet.ElementAt(_random.Next(0,alphabet.Length)).ToString();
                TextBlock lbl = new TextBlock();
                lbl.Text = symbol;
                lbl.FontSize = _random.Next(20, 50);
                lbl.RenderTransform = new RotateTransform(_random.Next(-45, 45));
                lbl.Margin = new Thickness(10,10,10,0);

                stringCaptcha+=symbol;
                SymnolsPanel.Children.Add(lbl);

            }

        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());

        }

        private void CaptchaButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateCaptcha();

        }
    }
}

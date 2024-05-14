using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace РКИС_ЛР_10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] itemsArray = { "White", "Black", "Red", "Blue", "Green", "Yellow","Orange","Gray","Purple" };

        public MainWindow()
        {
            InitializeComponent();
            foreach (string item in itemsArray)
            {
                colorCombo.Items  .Add(item);
                colorComboForCursor.Items  .Add(item);
            }
            colorCombo.SelectionChanged += ComboBox_SelectionChanged;
            colorCombo.SelectedIndex = 0;

            colorComboForCursor.SelectionChanged += ComboBoxForCursor_SelectionChanged;
            colorComboForCursor.SelectedIndex = 1;

            Color color = (Color)ColorConverter.ConvertFromString(itemsArray[0]);
            SolidColorBrush brush = new SolidColorBrush(color);

            canvas.Background = brush;

            Color colorForCursor = (Color)ColorConverter.ConvertFromString(itemsArray[1]);
            canvas.DefaultDrawingAttributes.Color = colorForCursor;
        }

        private void mi_open_Click(object sender, RoutedEventArgs e) { mi_open.Background = Brushes.LightGreen; }
        private void CheckBox_Click(object sender, RoutedEventArgs e) { ((FrameworkElement)sender).Visibility =Visibility.Hidden; }     

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (canvas != null && canvas.DefaultDrawingAttributes is DrawingAttributes inkCanvas)
            {
                inkCanvas.Width = e.NewValue;
                inkCanvas.Height = 10*e.NewValue;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (colorCombo.SelectedItem != null)
            {
                string selectedColor = colorCombo.SelectedItem.ToString();
                Color color = (Color)ColorConverter.ConvertFromString(selectedColor);
                SolidColorBrush colorb = new SolidColorBrush(color);

                canvas.Background = colorb;
            }
        }

        private void Msg_Dev(object sender, RoutedEventArgs e)              { MessageBox.Show("Разработчик - студент гр. 90002198, Ляшов Илья"); }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e) { if (canvas != null) canvas.EditingMode = InkCanvasEditingMode.EraseByPoint; }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e) { if (canvas != null) canvas.EditingMode = InkCanvasEditingMode.Ink; }

        private void Exit(object sender, MouseButtonEventArgs e)            { Application.Current.Shutdown(); }

        private void Exit(object sender, RoutedEventArgs e)                 { Application.Current.Shutdown(); }

        private void ComboBoxForCursor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (colorComboForCursor.SelectedItem != null)
            {
                string selectedColor = colorComboForCursor.SelectedItem.ToString();
                Color colorForCursor = (Color)ColorConverter.ConvertFromString(selectedColor);

                canvas.DefaultDrawingAttributes.Color = colorForCursor;
            }

        }
    }
}

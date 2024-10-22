using System;
using System.Windows;
using System.Windows.Media;


namespace gostev
{
    public partial class MainWindow : Window
    {
        private double radius;
        private SolidColorBrush currentColor = Brushes.Black;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Input_Click(object sender, RoutedEventArgs e)
        {
            string input = RadiusTextBox.Text;

            if (double.TryParse(input, out radius) && radius > 0)
            {
                System.Windows.Forms.MessageBox.Show("Радиус успешно установлен.", "Успех");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Введите корректное значение радиуса.", "Ошибка");
            }
        }

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            if (radius <= 0)
            {
                System.Windows.Forms.MessageBox.Show("Сначала введите радиус.", "Ошибка");
                return;
            }

            double area = Math.PI * Math.Pow(radius, 2);
            double circumference = 2 * Math.PI * radius;
            string result = "";

            if (SquareCheckBox.IsChecked == true)
            {
                result += $"Площадь круга: {area:F2}\n";
            }

            if (LengthCheckBox.IsChecked == true)
            {
                result += $"Длина окружности: {circumference:F2}\n";
            }

            if (string.IsNullOrEmpty(result))
            {
                System.Windows.Forms.MessageBox.Show("Выберите хотя бы один режим вычислений.", "Ошибка");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(result, "Результаты");
            }
        }

        private void Draw_Click(object sender, RoutedEventArgs e)
        {
            var colorDialog = new System.Windows.Forms.ColorDialog();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                currentColor = new SolidColorBrush(Color.FromArgb(
                    colorDialog.Color.A,
                    colorDialog.Color.R,
                    colorDialog.Color.G,
                    colorDialog.Color.B));
                DrawingCanvas.DefaultDrawingAttributes.Color = currentColor.Color;

            }
        }
    }
}

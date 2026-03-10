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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Практическая_работа_4_Краснова_Солодов.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private DoubleAnimation _currentFadeAnimation;
        public Page2()
        {
            InitializeComponent();
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            xInput.Clear();
            yInput.Clear();
            answer.Clear();

            foreach (var rb in funcs.Children.OfType<RadioButton>())
            {
                rb.IsChecked = false;
            }
        }

        private void countBtn_Click(object sender, RoutedEventArgs e)
        {
            string str_fx = "";

            foreach (var rb in funcs.Children.OfType<RadioButton>())
            {
                if (rb.IsChecked == true)
                {
                    str_fx = rb.Name;
                    break;
                }
            }
            Calculate(xInput.Text, yInput.Text, str_fx);
        }

        public bool Calculate(string temp_str_x, string temp_str_y, string str_fx) 
        {
            // Обработка точки в double
            if (temp_str_x.Contains('.')) temp_str_x = temp_str_x.Replace('.', ',');
            if (temp_str_y.Contains('.')) temp_str_y = temp_str_y.Replace(".", ","); 

            // Проверка на корректность данных
            bool xCheck = double.TryParse(temp_str_x, out var x);
            bool yCheck = double.TryParse(temp_str_y, out var y);

            // Исключение
            if (temp_str_x == "" || temp_str_y == "" || str_fx == "")
            {
                MessageBox.Show("Заполните поля: x и y\nВыберите функцию для расчетов.", "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            // Исключение
            if (xCheck == false || yCheck == false)
            {
                // 1. Остановка если есть чего
                if (_currentFadeAnimation != null)
                {
                    _currentFadeAnimation.Completed -= FadeOutAnimation_Completed;
                    perdulia_comm_image.BeginAnimation(Image.OpacityProperty, null);
                }

                // 2. Возврат в полное видимое состояние
                perdulia_comm_image.Opacity = 1.0;
                perdulia_comm_image.Visibility = Visibility.Visible;

                // 3.Создание анимки
                _currentFadeAnimation = new DoubleAnimation
                {
                    From = 1.0,                         // Начальная прозрачность 
                    To = 0.0,                           // Конечная прозрачность 
                    Duration = TimeSpan.FromSeconds(4), // Длительность анимации
                    AutoReverse = false,                // Не возвращаться обратно
                    FillBehavior = FillBehavior.Stop    // Остановиться в конечном состоянии
                };
                // 4. Добавление в конец остановки
                _currentFadeAnimation.Completed += FadeOutAnimation_Completed;

                // 5. Запуск анимки
                perdulia_comm_image.BeginAnimation(Image.OpacityProperty, _currentFadeAnimation);

                return false;
            }

            // Вычисление fx
            double fx = 0;
            switch (str_fx)
            {
                case "var1":
                    fx = Math.Sinh(x);
                    break;

                case "var2":
                    fx = Math.Pow(x, 2);
                    break;

                case "var3":
                    fx = Math.Pow(Math.E, x);
                    break;
            }

            double xy = x * y;
            double fx_plus_y = Math.Pow(fx + y, 2);

            if (xy > 0)
            {
                var ans = fx_plus_y - Math.Sqrt(fx * y);

                if (double.IsNaN(ans))
                {
                    MessageBox.Show("Ошибка в расчетах (NaN)", "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Stop);
                    return false;
                }
                else
                {
                    answer.Text = (ans).ToString();
                    return true;
                }
            }
            else if (xy < 0)
            {
                var ans = fx_plus_y + Math.Sqrt(Math.Abs(fx * y));

                if (double.IsNaN(ans))
                {
                    MessageBox.Show("Ошибка в расчетах (NaN)", "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Stop);
                    return false;
                }
                else
                {
                    answer.Text = (ans).ToString();
                    return true;
                }
            }
            else // xy == 0 (x == 0 или y == 0)
            {
                var ans = fx_plus_y + 1;

                if (double.IsNaN(ans))
                {
                    MessageBox.Show("Ошибка в расчетах (NaN)", "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Stop);
                    return false;
                }
                else
                {
                    answer.Text = (ans).ToString();
                    return true;
                }
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            Page3 newPage = new Page3();
            NavigationService.Navigate(newPage);
        }

        // Для пердули, не трогать!
        private void FadeOutAnimation_Completed(object sender, EventArgs e)
        {
            perdulia_comm_image.Visibility = Visibility.Collapsed;
            _currentFadeAnimation = null;
        }
    }
}

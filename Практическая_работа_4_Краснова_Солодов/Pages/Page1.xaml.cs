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

namespace Практическая_работа_4_Краснова_Солодов.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        /// <summary>
        /// Конструктыыыр
        /// </summary>
        public Page1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Функция вычисления по формуле
        /// </summary>
        /// <param name="x"> Параметр x</param>
        /// <param name="y"> Параметр y</param>
        /// <param name="z"> Параметр z</param>
        /// <returns> true, если вычисления прошли успешно, иначе false </returns>
        public bool Calculate(string x, string y, string z)
        {

            if (x != "" && y != "" && z != "")
            {
                if (x.Contains(".")) { x = x.Replace(".", ","); }
                if (y.Contains(".")) { y = y.Replace(".", ","); }
                if (z.Contains(".")) { z = z.Replace(".", ","); }

                bool xparce = double.TryParse(x, out var numx);
                bool yparce = double.TryParse(y, out var numy);
                bool zparce = double.TryParse(z, out var numz);

                if (xparce && yparce && zparce)
                {
                    MessageBox.Show(":)");
                    double res = ((2 * Math.Cos(numx - (Math.PI / 6))) / (0.5 + Math.Pow(Math.Sin(numy), 2))) * (1 + ((Math.Pow(numz, 2) / (3 - Math.Pow(numz, 2) / 5))));
                    answerTB.Text = res.ToString();
                    return true;
                }
                else { MessageBox.Show("Введено не число!"); return false; }
            }
            else { MessageBox.Show("Заполните x, y и z!"); return false; }
        }

        /// <summary>
        /// Функция перехода к вычислениям
        /// </summary>
        private void CalculateBtn_Click(object sender, RoutedEventArgs e)
        {
            Calculate(xTB.Text, yTB.Text, zTB.Text);
        }

        /// <summary>
        /// Функция очищения всех полей
        /// </summary>
        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            xTB.Clear();
            yTB.Clear();
            zTB.Clear();
            answerTB.Clear();
        }

        /// <summary>
        /// Функция перехода на следующую страницу
        /// </summary>
        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }
    }
}

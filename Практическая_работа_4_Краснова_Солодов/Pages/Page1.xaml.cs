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
        public Page1()
        {
            InitializeComponent();
        }

        public void Calculate(double x, double y, double z)
        {

        }

        private void CalculateBtn_Click(object sender, RoutedEventArgs e)
        {
            bool xparce = double.TryParse(xTB.Text, out var numx);
            bool yparce = double.TryParse(yTB.Text, out var numy);
            bool zparce = double.TryParse(zTB.Text, out var numz);
            if (xparce && yparce && zparce)
            {
                MessageBox.Show(":)");
                Calculate(numx, numy, numz);
            }
            else
            {
                MessageBox.Show("Введено не число!");
            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            xTB.Clear();
            yTB.Clear();
            zTB.Clear();
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

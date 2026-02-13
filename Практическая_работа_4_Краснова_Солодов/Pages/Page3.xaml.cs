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
using System.Windows.Forms.DataVisualization.Charting;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;



namespace Практическая_работа_4_Краснова_Солодов.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();

            ChartFunc.ChartAreas.Add(new ChartArea("Main"));
            ChartFunc.Series.Add(new Series("Точки"));
            
            ChartFunc.Series["Точки"].ChartArea = "Main";
            ChartFunc.Series["Точки"].ChartType = SeriesChartType.Line;
        }

        public void Calculate(decimal x)
        {
            bool flag_exception = false;

            double a = -1.25;
            decimal b = -1.5m;
            decimal c = 0.75m;
            decimal xk = 3.5m; // пердел
            decimal dx = 0.5m; // шаг
            List<decimal> axis_y_nums = new List<decimal>();
            List<decimal> axis_x_nums = new List<decimal>();
            string res = "";

            for (; x <= xk; x += dx)
            {
                if (x == 0)
                {

                }
                else
                {
                    try
                    {
                        decimal f = ((Convert.ToDecimal(Math.Pow(10, -2)) * b * c) / x) + Convert.ToDecimal(Math.Cos(Math.Sqrt(Convert.ToDouble(Convert.ToDecimal(Math.Pow(a, 3)) * x))));
                        axis_x_nums.Add(x);
                        axis_y_nums.Add(f);
                    }
                    catch (DivideByZeroException)
                    {
                        MessageBox.Show($"Выполнение прервано\nпо причине: x = 0\n(деление на ноль)\nТочек посчитано: {axis_y_nums.Count}");
                        flag_exception = true;
                        break;
                    }
                    catch (System.OverflowException)
                    {
                        MessageBox.Show($"Выполнение прервано\nпо причине: переполнение типа Decimal\n(более 28 символов после запятой)\nТочек посчитано: {axis_y_nums.Count}");
                        flag_exception = true;
                        break;
                    }
                }    
            }

            foreach (decimal i in axis_y_nums)
            {
                res += axis_y_nums.IndexOf(i) + 1 + $": {i}\n\n";
            }

            if (res == "" && flag_exception == false) { MessageBox.Show("0 точек"); }
            else
            {
                answerTB.Text = res;
                ChartFunc.Series["Точки"].Points.DataBindXY(axis_x_nums, axis_y_nums);
            }
        }

        private void CalculateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (xTB.Text != "")
            { 
                if (xTB.Text.Contains(".")) { xTB.Text = xTB.Text.Replace(".", ","); }
                bool xparce = double.TryParse(xTB.Text, out var numx);

                if (xparce)
                {
                    MessageBox.Show(":)");
                    Calculate(Convert.ToDecimal(numx));
                }
                else { MessageBox.Show("Введено не число!"); }
            }
            else { MessageBox.Show("Заполните x, y и z!"); }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            xTB.Clear();
            answerTB.Clear();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }
    }
}

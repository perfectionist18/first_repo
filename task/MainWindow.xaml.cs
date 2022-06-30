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

namespace task
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)
                         System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string a, b;
            a = TextBox1.Text;
            b = TextBox2.Text;
            string[] set1 = a.Split(',');
            string[] set2 = b.Split(',');
            int[] A, B;
            A = new int[set1.Length];
            B = new int[set2.Length];
            bool ok;
            for (int i = 0; i < set1.Length; i++)
            {
                ok = Int32.TryParse(set1[i], out A[i]);
                if (!ok)
                {
                    MessageBox.Show("Задано некоректну числову множину!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            for (int i = 0; i < set2.Length; i++)
            {
                ok = Int32.TryParse(set2[i], out B[i]);
                if (!ok)
                {
                    MessageBox.Show("Задано некоректну числову множину!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            for (int i = 0; i < B.Length; i++)
            {
                DataGridRes.Columns.Add(new DataGridTextColumn());
            }            for (int i = 0; i < B.Length; i++)
            {
                DataGridRes.Columns[i].Header = B[i];            }

            for (int i = 0; i < A.Length; i++)
            {
                DataGridRes.Items.Add(A[i]);
            }

            int res;
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < B.Length; j++)
                {
                    res = 3 * A[i] - B[j];
                    if (res < 1)
                    {
                        ListBoxTemp.Items.Add("1");
                    }
                    else
                    {
                        ListBoxTemp.Items.Add("0");
                    }
                }
            }

        }
    }
}

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

namespace Craps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            string[] values = new string[6] { "●", "●\n\n●", "●\n  ●\n    ●", "●     ●\n\n●     ●", "●     ●\n    ●   \n●     ●", "●     ●\n●     ●\n●     ●" };
            Random random = new Random();
            Cube1.Content = values[random.Next(0, values.Length)];
            Cube2.Content = values[random.Next(0, values.Length)];

            if (Info.Text != "Следующий ход: Игрок 2")
                Info.Text = "Следующий ход: Игрок 2";
            else
                Info.Text = "Следующий ход: Игрок 1";
        }
    }
}

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

        Player player1 = new Player("Tim");
        Player player2 = new Player("Bob");

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            // Присвоить имена игрокам
            PlayerName1.Text = player1.Name;
            PlayerName2.Text = player2.Name;

            // Очистить кубики
            Cube1.Content = "";
            Cube2.Content = "";
        }

        private void Roll_Click(object sender, RoutedEventArgs e)
        {
            string[] values = new string[6] { "●", "●\n\n●", "●\n  ●\n    ●", "●     ●\n\n●     ●", "●     ●\n    ●   \n●     ●", "●     ●\n●     ●\n●     ●" };
            Random random = new Random();
            int index1 = random.Next(0, values.Length);
            int index2 = random.Next(0, values.Length); 
            Cube1.Content = values[index1];
            Cube2.Content = values[index2];

            if (Info.Text != "Следующий ход: Игрок 2")
            {
                Info.Text = "Следующий ход: Игрок 2";

                player1.Turns++;
                player1.Points += index1 + index2 + 2;

                Turns1.Text = $"Turns: {player1.Turns}";
                Points1.Text = $"+{player1.Points}";
                Total1.Text = $"Total: 0";
            }    
            else
                Info.Text = "Следующий ход: Игрок 1";
        }

        class Player
        {
            public Player(string name)
            {
                Name = name;
                Points = 0;
                Turns = 0;
            }

            public string Name { get; set; }       
            public int Points { get; set; }
            public int Turns { get; set; }


        }
    }
}

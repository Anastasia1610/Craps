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

        Player player1 = new Player();
        Player player2 = new Player();

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Info.Text = "Ходит Игрок 1\n\nИграть заново - нажмите Start";

            // Обнуление игроков
            player1 = new Player("Tim");
            player2 = new Player("Bob");
            PlayerName1.Text = player1.Name;
            Turns1.Text = $"Turns: {player1.Turns}";
            Points1.Text = $"+{player1.Points}";
            Total1.Text = $"Total: {player1.Total}";
            PlayerName2.Text = player2.Name;
            Turns2.Text = $"Turns: {player2.Turns}";
            Points2.Text = $"+{player2.Points}";
            Total2.Text = $"Total: {player2.Total}";

            // Очистить кубики
            Cube1.Content = "";
            Cube2.Content = "";
        }

        private void Roll_Click(object sender, RoutedEventArgs e)
        {
            // Кнопка не нажимается, пока не нажали Start
            if(string.IsNullOrWhiteSpace(player1.Name) || string.IsNullOrWhiteSpace(player2.Name))
                return; 

            // Заполнение кубиков
            string[] values = new string[6] { "●", "●\n\n●", "●\n  ●\n    ●", "●     ●\n\n●     ●", "●     ●\n    ●   \n●     ●", "●     ●\n●     ●\n●     ●" };
            Random random = new Random();
            int index1 = random.Next(0, values.Length);
            int index2 = random.Next(0, values.Length); 
            Cube1.Content = values[index1];
            Cube2.Content = values[index2];

            // Логика игры
            if (Info.Text != "Ходит Игрок 2\n\nИграть заново - нажмите Start")
            {
                Info.Text = "Ходит Игрок 2\n\nИграть заново - нажмите Start";

                player1.Turns++;
                player1.Points = index1 + index2 + 2;
                player1.Total += player1.Points;

                Turns1.Text = $"Turns: {player1.Turns}";
                Points1.Text = $"+{player1.Points}";
                Total1.Text = $"Total: {player1.Total}";
            }
            else
            {
                Info.Text = "Ходит Игрок 1\n\nИграть заново - нажмите Start";

                player2.Turns++;
                player2.Points = index1 + index2 + 2;
                player2.Total += player2.Points;

                Turns2.Text = $"Turns: {player2.Turns}";
                Points2.Text = $"+{player2.Points}";
                Total2.Text = $"Total: {player2.Total}";
            }

            // Проверка на выигрыш
            if (player1.Turns == 5 && player2.Turns == 5)
            {
                // Вывод результатов
                if(player1.Total > player2.Total)
                    Info.Text = $"Выиграл {player1.Name} со счетом {player1.Total}:{player2.Total}.\n\n" +
                        $"Играть заново - нажмите Start";
                else if(player1.Total < player2.Total)
                    Info.Text = $"Выиграл {player2.Name} со счетом {player2.Total}:{player1.Total}.\n\n" +
                            $"Играть заново - нажмите Start";
                else
                    Info.Text = $"Победила дружба! Счет {player1.Total}:{player2.Total}.\n\n" +
                           $"Играть заново - нажмите Start";

                // Обнуление игроков
                player1 = new Player();
                player2 = new Player();
            }
        }

        class Player
        {
            public Player()
            {
            }

            public Player(string name)
            {
                Name = name;
                Points = 0;
                Turns = 0;
                Total = 0;
            }

            public string Name { get; set; }       
            public int Points { get; set; }
            public int Turns { get; set; }
            public int Total { get; set; }  

        }
    }
}

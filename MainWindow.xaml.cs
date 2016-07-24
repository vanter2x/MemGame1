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

namespace MemGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game game;
        public MainWindow()
        {
            InitializeComponent();
            foreach (Button x in gdGame.Children)
            {
                x.Content = "x";
                //x.Click += game.ClickButton();
            }
                
            
            game = new MemGame.Game(gdGame);
            game.RandomNr();
            ImageBrush xx = new ImageBrush(1.png);
            foreach (Button x in gdGame.Children)
            {
                

                x.Click += button1_Click;
                x.Background= 
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            game.ClickButton(sender, e);
        }
    }
}

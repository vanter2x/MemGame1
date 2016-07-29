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
            
            game = new Game(gdGame);
            game.RandomNr();
            string xx, yy;
            xx = "\\backg\\light.png";
            yy = "sdf";
            game.LoadPicture(xx, yy);
            game.LoadButtonPicture(gdGame);
            //Image xx = new Image();
            //xx.Source = ImageSource();
            foreach (Button x in gdGame.Children)
            {
                

                x.Click += button1_Click;
                //x.Content = x.Tag.ToString();
               // x.Background= 
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            game.ClickButton(sender, e,gdGame);
        }
    }
}

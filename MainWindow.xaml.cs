using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;


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
           
            btnNewGame.Background = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\ggraph\\ng.png", UriKind.Absolute)));
            game = new Game(gdGame);
            NewGame();
            //Image xx = new Image();
            //xx.Source = ImageSource();
            foreach (Button x in gdGame.Children)
            {


                x.Click += button1_Click;

                //x.Content = x.Tag.ToString();
                // x.Background= 
            }

        }

        private void NewGame()
        {
            game.RandomNr();
            string xx, yy;
            xx = "\\backg\\light.png";
            yy = "sdf";
            game.LoadPicture(xx, yy);
            game.LoadButtonPicture(gdGame);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
            
            game.ClickButton(sender, e,gdGame,btnNewGame);
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
            btnNewGame.Visibility = Visibility.Hidden;
        }
    }
}

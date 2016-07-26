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
            Style style = new Style();
            Trigger changer = new Trigger() { Property = IsMouseOverProperty, Value = true };
            //changer.SetValue(IsMouseOverProperty, true);
            changer.Setters.Add(new Setter() { Property = OpacityProperty, Value = 0.2 });
            style.Triggers.Add(changer);

            

            foreach (Button x in gdGame.Children)
            {
                x.Content = "x";
                Image image = new Image();
                image.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\ico\\2.png", UriKind.Absolute));
                x.Background = new System.Windows.Media.ImageBrush(image.Source);

                //x.Click += game.ClickButton();
            }
            
            
            
            //image1.Source = Game.LoadBitmapFromResource("Resources/2.png");
            
            //button1.LayoutTransform = image1;
            game = new Game(gdGame);
            game.RandomNr();
            //Image xx = new Image();
            //xx.Source = ImageSource();
            foreach (Button x in gdGame.Children)
            {
                

                x.Click += button1_Click;
               // x.Background= 
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            game.ClickButton(sender, e);
        }
    }
}

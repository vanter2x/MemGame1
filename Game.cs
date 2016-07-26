using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MemGame
{
    public class Game
    {
        public List<Button> Btn = new List<Button>(); //lista Buttons
        private StackPanel stcPanel = new StackPanel();
        Button help = new Button();
        bool count = false; // pomocnicza zmienna (czy jakis button jest wciśniety)
        
        //public Game() { }
        public Game(Grid grid) //konstruktor przypisuje referencje z buttonow z mainWindow do Listy<Buttonów>
        {
            foreach (Button b in grid.Children)
                Btn.Add(b);

        }
        public void RandomNr() // Metoda losuje podwójne liczby z zakresu 0-20 i przypisuje do Button.Taga
        {
            List<int> number = new List<int>(); //pomocnicza lista wypełniona podwójnymi liczbami 0-20
            for (int i = 0; i < 21; i++) number.Add(i);
            for (int i = 0; i < 21; i++) number.Add(i);
            var ii = 0; // pomocnicza zmienna 
            Random rand = new Random();
            foreach (Button b in Btn)
            {
                ii = rand.Next(number.Count - 1); // losowanie liczby z listy i przypisanie do Taga
                b.Tag = number[ii];
                //Image x = new Image();
                //x.Source = "1.png";

                number.RemoveAt(ii); // usunięcie wylosowanej liczby z listy
                b.Content = b.Tag;
               // b.Content = x;
            }
        }
        public void ClickButton(object sender, RoutedEventArgs e) //obsługa kliknięcia na przycisk
        {
            // stworzenie dwóch pomocniczych buttonów i przypisanie do nich naciśniętych buttonów
            
            Button x = new Button();
            x = (Button)sender;
            // obsługa zdarzenia
            if (count == false)
            {
                Image image = new Image();
                image.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\ico\\11.png", UriKind.Absolute));
                x.Background = new System.Windows.Media.ImageBrush(image.Source);
                count = true;
                help = (Button)sender;
                x.IsEnabled = false;  
            }
            else
            {
                Image image = new Image();
                image.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\ico\\11.png", UriKind.Absolute));
                x.Background = new System.Windows.Media.ImageBrush(image.Source);
                count = false;
                System.Threading.Thread.Sleep(1000);
                if (x.Tag.ToString() == help.Tag.ToString())
                {
                    //MessageBox.Show("sddsad");
                    x.Visibility = Visibility.Hidden;
                    help.Visibility = Visibility.Hidden;
                    //System.Threading.Thread.Sleep(1000);

                }
                else help.IsEnabled = true;

                //System.Windows.Media.RadialGradientBrush ccc = new System.Windows.Media.RadialGradientBrush() {  }
               // x.Background = new System.Windows.Media.r
            }
        }

        public static System.Windows.Media.Imaging.BitmapImage LoadBitmapFromResource(string pathInApplication, System.Reflection.Assembly assembly = null)
        {
            if (assembly == null)
            {
                assembly = System.Reflection.Assembly.GetCallingAssembly();
            }

            if (pathInApplication[0] == '/')
            {
                pathInApplication = pathInApplication.Substring(1);
            }
            return new System.Windows.Media.Imaging.BitmapImage(new Uri(@"pack://application:,,,/" + assembly.GetName().Name + ";component/" + pathInApplication, UriKind.Absolute));
        }

    }

    }


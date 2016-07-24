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
        public List<Button> Btn = new List<Button>();
        byte count = 0;
        Button help = new Button();
        //public Game() { }
        public Game(Grid grid)
        {
            foreach (Button b in grid.Children)
                Btn.Add(b);

        }
        public void RandomNr()
        {
            List<int> number = new List<int>();
            for (int i = 0; i < 21; i++) number.Add(i);
            for (int i = 0; i < 21; i++) number.Add(i);
            var ii = 0;
            Random rand = new Random();
            foreach (Button b in Btn)
            {
                ii = rand.Next(number.Count - 1);
                b.Tag = number[ii];
                Image x = new Image();
                x.Source = "1.png";

                number.RemoveAt(ii);
                b.Content = b.Tag;
                b.Content = x;
            }
        }
        public void ClickButton(object sender, RoutedEventArgs e)
        {
            
            Button x = new Button();
            x = (Button)sender;
            if(count == 0)
            {
                count += 1;
                help = (Button)sender;
                x.IsEnabled = false;  
            }
            else
            {
                count = 0;
                System.Threading.Thread.Sleep(1000);
                if (x.Tag.ToString() == help.Tag.ToString())
                {
                    //MessageBox.Show("sddsad");
                    x.Visibility = Visibility.Hidden;
                    help.Visibility = Visibility.Hidden;
                    //System.Threading.Thread.Sleep(1000);

                }
                else help.IsEnabled = true;
            }
        }
        
            
        }

    }


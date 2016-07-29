﻿using System;
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
        Image[] buttPicture = new Image[20];
        Image buttBackG = new Image();

        public List<Button> Btn = new List<Button>(); //lista Buttons
        private StackPanel stcPanel = new StackPanel();
        Button help = new Button() { Tag = 300 };
        Button x = new Button() { Tag = 100 };
        
        bool count = false; // pomocnicza zmienna (czy jakis button jest wciśniety)
        
        //public Game() { }
        public Game(Grid grid) //konstruktor przypisuje referencje z buttonow z mainWindow do Listy<Buttonów>
        {
            foreach (Button b in grid.Children)
                Btn.Add(b);

        }
        
        //ładowanie obrazów do image
        public void LoadPicture(string bPicture, string bBackG)
        {
            
            buttBackG.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + bPicture, UriKind.Absolute));
            for(int i=0;i<20;i++)
            {
                buttPicture[i] = new Image();
                buttPicture[i].Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\ios\\"+(i+1).ToString()+".png", UriKind.Absolute));
            }
        } 

        public void LoadButtonPicture(Grid grid)
        {
            for (int i = 0; i < 40; i++)
                Btn[i].Background = new System.Windows.Media.ImageBrush(buttBackG.Source);
        }


        
        public void RandomNr() // Metoda losuje podwójne liczby z zakresu 0-20 i przypisuje do Button.Taga
        {
            List<int> number = new List<int>(); //pomocnicza lista wypełniona podwójnymi liczbami 0-20
            for (int i = 0; i < 20; i++) number.Add(i);
            for (int i = 0; i < 20; i++) number.Add(i);
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
        public async void ClickButton(object sender, RoutedEventArgs e,Grid grid) //obsługa kliknięcia na przycisk
        {
            // stworzenie dwóch pomocniczych buttonów i przypisanie do nich naciśniętych buttonów



            // obsługa zdarzenia
            if (count == false)
            {
                
                x = (Button)sender;
                //Image image = new Image();
                //image.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\ios\\", UriKind.Absolute));
                x.Background = new System.Windows.Media.ImageBrush(buttPicture[(int)x.Tag].Source);
                count = true;
                

                //help.IsEnabled = false;
                //x.IsEnabled = false;  
            }
            else
            {
                
                help = (Button)sender;
                
                //Image image = new Image();
                //image.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\ios\\17.png", UriKind.Absolute));
                //x.Visibility = Visibility.Hidden;

                help.Background = new System.Windows.Media.ImageBrush(buttPicture[(int)help.Tag].Source);
                //MessageBox.Show("sddsad");
                count = false;
                grid.IsEnabled = false;
                


                if (x.Tag.ToString() != help.Tag.ToString())
                {
                    await Task.Delay(1000);
                    //image.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\ios\\20.png", UriKind.Absolute));
                    x.Background = new System.Windows.Media.ImageBrush(buttBackG.Source);
                    help.Background = x.Background;
                    help.IsEnabled = true;
                    grid.IsEnabled = true;
                    //MessageBox.Show("sddsad");


                }
                else
                {
                    await Task.Delay(1000);
                    x.Visibility = Visibility.Hidden;
                    help.Visibility = Visibility.Hidden;
                    
                    grid.IsEnabled = true;
                }
                //System.Windows.Media.RadialGradientBrush ccc = new System.Windows.Media.RadialGradientBrush() {  }
               // x.Background = new System.Windows.Media.r
            }
        }


    }
}

    


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

namespace wpf_my_menu
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        bool alreadyPressed = false;

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            if (checkMenuItem.IsChecked == true)
            {
                messageMenuItem.IsEnabled = false;
            }
        }
        private void Uncheck_Click(object sender, RoutedEventArgs e)
        {
            if (checkMenuItem.IsChecked == false)
            {
                messageMenuItem.IsEnabled = true;
            }
        }
        private void CheckContext_Click(object sender, RoutedEventArgs e)
        {
            if (ContextCheckItem.IsChecked == true)
            {
                ContextMessageItem.IsEnabled = false;
            }
        }
        private void UncheckContext_Click(object sender, RoutedEventArgs e)
        {
            if (ContextCheckItem.IsChecked == false)
            {
                ContextMessageItem.IsEnabled = true;
            }
        }


        private void GlobalShortCut(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                checkMenuItem.IsChecked = !checkMenuItem.IsChecked;
                messageMenuItem.IsEnabled = !messageMenuItem.IsEnabled;

                ContextCheckItem.IsChecked = !ContextCheckItem.IsChecked;
                ContextMessageItem.IsEnabled = !ContextMessageItem.IsEnabled;
            }
            else if (e.Key == Key.E && Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                try
                {
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (e.Key == Key.M && Keyboard.IsKeyDown(Key.LeftCtrl) && messageMenuItem.IsEnabled == true)
            {
                messageClick(sender, e);
            }
        }

        private void AboutShortCut(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A && Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                aboutClick(sender, e);
            }
        }


        private void exitClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void aboutClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Some info about program!");
        }
        private void messageClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello!");
        }

       

        private void sizeClick(object sender, KeyEventArgs e)
        {
            MenuItem newMenuItem1 = new MenuItem();
            MenuItem newMenuItem2 = new MenuItem();
            MenuItem newMenuItem3 = new MenuItem();
            MenuItem newExistMenuItem = (MenuItem)this.MainMenu.Items[1];

            if (Keyboard.IsKeyDown(Key.D) && ! alreadyPressed)
            {
                alreadyPressed = true;
                newMenuItem1.Header = "50%";
                newMenuItem2.Header = "75%";
                newMenuItem2.IsCheckable = true;
                newMenuItem3.Header = "100%";
                newExistMenuItem.Items.Add(newMenuItem1);
                newExistMenuItem.Items.Add(newMenuItem2);
                newExistMenuItem.Items.Add(newMenuItem3);
            }
           
            if(Keyboard.IsKeyDown(Key.S))
            {
                newMenuItem2 = e.OriginalSource as MenuItem;
                newMenuItem2.IsChecked = !newMenuItem2.IsChecked;
            }
        }



    }
}

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
using Pairs.ViewModel;
using Pairs.Models;

namespace Pairs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //public Game newGame;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as UserVM).Avatar = (this.DataContext as UserVM).ImageVM.Previous();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox.Text.ToString()))
            {
                MessageBox.Show("Invalid name!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                b1.IsEnabled = false;
                b2.IsEnabled = false;
                b3.IsEnabled = false;
                b4.IsEnabled = true;
                b7.IsEnabled = true;
               // (this.DataContext as UserVM).ImageVM.Index = -1;
                (this.DataContext as UserVM).UserList.Add(new User(textBox.Text, img.Source.ToString()));
                list.SelectedItem = (this.DataContext as UserVM).UserList[(this.DataContext as UserVM).UserList.Count - 1];
                textBox.Text = "";
                textBox.Visibility = Visibility.Hidden;
                nameLabel.Visibility = Visibility.Hidden;
                Serializer.Serialize((this.DataContext as UserVM).UserList, "users.xml");
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as UserVM).Avatar = (this.DataContext as UserVM).ImageVM.Next();
        }

        private void NewUser_Click(object sender, RoutedEventArgs e)
        {
            b1.IsEnabled = true;
            b2.IsEnabled = true;
            b3.IsEnabled = true;
            b4.IsEnabled = false;
            b5.IsEnabled = false;
            b6.IsEnabled = false;
            b7.IsEnabled = false;
            textBox.Visibility = Visibility.Visible;
            nameLabel.Visibility = Visibility.Visible;
            (this.DataContext as UserVM).Avatar = (this.DataContext as UserVM).ImageVM.Next();
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (list.SelectedItem != null)
            {
                (this.DataContext as UserVM).UserList.Remove(list.SelectedItem as User);
                (this.DataContext as UserVM).Avatar = "";
                b5.IsEnabled = false;
                b6.IsEnabled = false;

                Serializer.Serialize((this.DataContext as UserVM).UserList, "users.xml");
            }
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {

                Views.Menu myMenu = new Views.Menu();
               myMenu.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void list_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            b5.IsEnabled = true;
            b6.IsEnabled = true;
        }

        private void listView_Click(object sender, RoutedEventArgs e)//cand dai click pe un obiect din lista currentUser primeste utilizatorul selctat
        {
            var item = (sender as ListBox).SelectedItem;
            if (item != null)
            {
                (this.DataContext as UserVM).CurrentUser = (User)item;
                (this.DataContext as UserVM).Avatar = (this.DataContext as UserVM).CurrentUser.Avatar;
            }
        }
    }
}

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
using System.Windows.Shapes;

namespace AnswersApp
{
    /// <summary>
    /// Логика взаимодействия для ListUsers.xaml
    /// </summary>
    public partial class ListUsers : Window
    {
        public ListUsers()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            UsersDGrid.ItemsSource = Helper.db.Users.ToList();
        }

        private void UsersDGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User user = UsersDGrid.SelectedItem as User;
            if (user != null)
            {
                Helper.db.SaveChanges();
                LoadData();
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            new Menu().Show();
            this.Close();
        }
    }
}

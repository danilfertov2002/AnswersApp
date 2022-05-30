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
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void UsersListBtn_Click(object sender, RoutedEventArgs e)
        {
            new ListUsers().Show();
            this.Close();
        }

        private void TasksListBtn_Click(object sender, RoutedEventArgs e)
        {
            new ListTasks().Show();
            this.Close();
        }

        private void MyAccountBtn_Click(object sender, RoutedEventArgs e)
        {
            new PersonalAccount().Show();
            this.Close();
        }
    }
}

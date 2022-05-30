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
using Microsoft.EntityFrameworkCore;

namespace AnswersApp
{
    /// <summary>
    /// Логика взаимодействия для ListTasks.xaml
    /// </summary>
    public partial class ListTasks : Window
    {
        public ListTasks()
        {
            InitializeComponent();
            LoadData();
            TaskGrid.SelectedItem = null;
            User currentUser = new User();
            currentUser = Helper.userSession;
            DataContext = currentUser;
        }
        private void LoadData()
        {
            TaskGrid.ItemsSource = Helper.db.Tasks.Where(t => t.IdStatusTask == 1).Include(u => u.IdCreatorNavigation).ToList();
        }

        private void TaskGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Task selectedTask = TaskGrid.SelectedItem as Task;
        }
        private void TaskGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Task selectedTask = TaskGrid.SelectedItem as Task;
            Helper.task = selectedTask;
            new TaskWindowSearch(selectedTask).Show();
            this.Close();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            new Menu().Show();
            this.Close();
        }

        private void SearchBtn_Click_1(object sender, RoutedEventArgs e)
        {
            var search = Helper.db.Users.FirstOrDefault(q => q.Login == LoginBox.Text);
            if (search != null)
            {
                Task task = Helper.db.Tasks.FirstOrDefault(t => t.IdCreator == search.Id);
                new SeacrhLoginTask(task).Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
            }
        }
    }
}

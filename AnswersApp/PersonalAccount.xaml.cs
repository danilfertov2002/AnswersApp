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
    /// Логика взаимодействия для PersonalAccount.xaml
    /// </summary>
    public partial class PersonalAccount : Window
    {
        public PersonalAccount()
        {
            InitializeComponent();
            User currentUser = new User();
            currentUser = Helper.userSession;
            DataContext = currentUser;
            LoadData(currentUser);
            LoadData1(currentUser);
        }

        private void LoadData(User currentUser)
        {
            UserTasks.ItemsSource = Helper.db.Tasks.Where(t => t.IdCreator == currentUser.Id).Include(s => s.IdStatusTaskNavigation).ToList();
        }

        private void LoadChangedData()
        {
            UserTasks.ItemsSource = Helper.db.Tasks.Where(t => t.IdCreator == Helper.userSession.Id).Include(s => s.IdStatusTaskNavigation).ToList();
        }

        private void LoadData1(User currentUser)
        {
            UserTasks_Copy.ItemsSource = Helper.db.Tasks.Where(t => t.IdAccepted == currentUser.Id).Include(s => s.IdStatusTaskNavigation).ToList();
        }

        private void LoadChangedData1()
        {
            UserTasks_Copy.ItemsSource = Helper.db.Tasks.Where(t => t.IdAccepted == Helper.userSession.Id).Include(s => s.IdStatusTaskNavigation).ToList();
        }

        private void BackBtn_Click_1(object sender, RoutedEventArgs e)
        {
            new Menu().Show();
            this.Close();
        }

        private void UserTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Task selectedTask = UserTasks.SelectedItem as Task;

            if (selectedTask != null)
            {
                if (selectedTask.IdStatusTask == 1)
                {
                    selectedTask.IdStatusTask = 2;
                }
                else if (selectedTask.IdStatusTask == 2)
                {
                    selectedTask.IdStatusTask = 3;
                }
                else if (selectedTask.IdStatusTask == 3)
                {
                    selectedTask.IdStatusTask = 1;
                }
                Helper.db.SaveChanges();
                LoadChangedData();
            }

            UserTasks.SelectedItem = null;
        }

        private void HistoryBtn_Click(object sender, RoutedEventArgs e)
        {
            new HistoryTask().Show();
            this.Close();
        }

        private void UserTasks_SelectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            Task selectedTask = UserTasks_Copy.SelectedItem as Task;

            if (selectedTask != null)
            {
                if (selectedTask.IdStatusTask == 2)
                {
                    selectedTask.IdStatusTask = 3;
                }
                else if (selectedTask.IdStatusTask == 3)
                {
                    selectedTask.IdStatusTask = 2;
                }
                Helper.db.SaveChanges();
                LoadChangedData1();
            }

            UserTasks_Copy.SelectedItem = null;
        }
    }
}

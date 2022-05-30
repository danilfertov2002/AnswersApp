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
    /// Логика взаимодействия для TaskWindowSearch.xaml
    /// </summary>
    public partial class TaskWindowSearch : Window
    {
        public TaskWindowSearch(Task selectedTask)
        {
            InitializeComponent();
            LoadData(selectedTask);
            Task currentTask = selectedTask;
            DataContext = currentTask;
        }

        private void LoadData(Task selectedTask)
        {

        }

        private void AcceptBtn_Click(object sender, RoutedEventArgs e)
        {
            Task currentTask = Helper.task;
            DataContext = currentTask;
            currentTask.IdStatusTask = 2;
            currentTask.IdAccepted = Helper.userSession.Id;
            Helper.db.SaveChanges();
            MessageBox.Show("Вы приняли задание");
            new ListTasks().Show();
            this.Close();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            new ListTasks().Show();
            this.Close();
        }
    }
}

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
    /// Логика взаимодействия для SeacrhLoginTask.xaml
    /// </summary>
    public partial class SeacrhLoginTask : Window
    {
        public SeacrhLoginTask(Task selectedTask)
        {
            InitializeComponent();
            LoadData(selectedTask);
            Task currentTask = selectedTask;
            DataContext = currentTask;
        }

        private void LoadData(Task selectedTask)
        {

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            new ListTasks().Show();
            this.Close();
        }
    }
}

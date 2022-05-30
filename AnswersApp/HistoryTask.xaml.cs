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
    /// Логика взаимодействия для HistoryTask.xaml
    /// </summary>
    public partial class HistoryTask : Window
    {
        public HistoryTask()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                UserTasks.ItemsSource = Helper.db.Tasks.Where(t => t.IdAccepted == Helper.userSession.Id && t.IdStatusTask == 3).Include(s => s.IdStatusTaskNavigation).ToList();
            }
            catch
            {

            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            new PersonalAccount().Show();
            this.Close();
        }
    }
}

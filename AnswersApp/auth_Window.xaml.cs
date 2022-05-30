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
    /// Логика взаимодействия для auth_Window.xaml
    /// </summary>
    public partial class auth_Window : Window
    {
        public auth_Window()
        {
            InitializeComponent();
        }

        private void Auth_Click(object sender, RoutedEventArgs e)
        {
            if (LoginBox.Text == "" || PassBox.Password == "")
            {
                MessageBox.Show("Пожалуйста, введите логин или пароль!", "Ошибка");
            }
            else
            {
                User user = Helper.db.Users.FirstOrDefault(q => q.Login == LoginBox.Text && q.Password == PassBox.Password);
                if (user != null)
                {
                    Helper.userSession = user;
                    Helper.db.SaveChanges();
                    MessageBox.Show("Вы успешно вошли!");
                    new Menu().Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!");
                }
            }
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            new RegistrationWindow().Show();
            this.Close();
        }
    }
}

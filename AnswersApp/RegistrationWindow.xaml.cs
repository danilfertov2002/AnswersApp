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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            string FirstName = firstNameBox.Text.Trim();
            string SecondName = secondNameBox.Text.Trim();
            string MiddleName = middleNameBox.Text.Trim();
            string Login = LoginBox.Text.Trim();
            string Password = PasswordBox.Text.Trim();
            string NumberPhone = numberPhoneBox.Text.Trim();
            if (Login.Length < 3)
            {
                LoginBox.ToolTip = "Логин введен не правильно!";
                LoginBox.Background = Brushes.Red;
            }
            else if (Password.Length < 3)
            {
                PasswordBox.ToolTip = "Пароль введен не правильно!";
                PasswordBox.Background = Brushes.Red;
            }
            else if (FirstName.Length < 3)
            {
                firstNameBox.ToolTip = "Имя введено не правильно!";
                firstNameBox.Background = Brushes.Red;
            }
            else if (SecondName.Length < 3)
            {
                secondNameBox.ToolTip = "Фамилия введена не правильно!";
                secondNameBox.Background = Brushes.Red;
            }
            else if (MiddleName.Length < 3)
            {
                middleNameBox.ToolTip = "Отчество введено не правильно!";
                middleNameBox.Background = Brushes.Red;
            }
            else if (NumberPhone.Length < 9)
            {
                numberPhoneBox.ToolTip = "Телефон введен не правильно!";
                numberPhoneBox.Background = Brushes.Red;
            }
            else
            {
                LoginBox.ToolTip = "";
                LoginBox.Background = Brushes.Transparent;

                PasswordBox.ToolTip = "";
                PasswordBox.Background = Brushes.Transparent;

                firstNameBox.ToolTip = "";
                firstNameBox.Background = Brushes.Transparent;

                secondNameBox.ToolTip = "";
                secondNameBox.Background = Brushes.Transparent;

                middleNameBox.ToolTip = "";
                middleNameBox.Background = Brushes.Transparent;

                numberPhoneBox.ToolTip = "";
                numberPhoneBox.Background = Brushes.Transparent;

                User user = new User()
                {
                    Login = Login,
                    Password = Password,
                    FirstName = FirstName,
                    SecondName = SecondName,
                    MiddleName = MiddleName,
                    NumberPhone = NumberPhone,
                };
                Helper.db.Users.Add(user);
                Helper.db.SaveChanges();

                MessageBox.Show("Вы успешно зарегистрированы!");

                new auth_Window().Show();
                this.Close();

            }
        }

        private void BackAuthBtn_Click(object sender, RoutedEventArgs e)
        {
            new auth_Window().Show();
            this.Close();
        }
    }
}

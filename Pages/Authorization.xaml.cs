using StudentProgress.Models;
using StudentProgress.ApplicationData;
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

namespace StudentProgress.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void BtnJoin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var UserObj = StudentProgressEntities.GetContext().Users.FirstOrDefault(x => x.Login == TbLogin.Text && x.Password == TbPassword.Password);
                if (UserObj == null)
                {
                    MessageBox.Show("Такого пользователя не существует!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (UserObj.ID_Role)
                    {
                        case 1:
                            MessageBox.Show("Зравствуйте, Преподаватель ", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            AppFrame.MainFrame.Navigate(new MainFormTeacher());
                            break;
                        case 2:
                            MessageBox.Show("Зравствуйте, Студент ", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            AppFrame.MainFrame.Navigate(new MainFormStudent());
                            break;
                        case 3:
                            MessageBox.Show("Зравствуйте, Директор ", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            AppFrame.MainFrame.Navigate(new MainForm());
                            break;
                        case 4:
                            MessageBox.Show("Зравствуйте, Администратор ", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            AppFrame.MainFrame.Navigate(new MainForm());
                            break;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка" + Ex.Message.ToString()+ "Критическая ошибка!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnGuest_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

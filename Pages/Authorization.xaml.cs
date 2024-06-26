﻿using Microsoft.Office.Interop.Excel;
using StudentProgress.Model;
using StudentProgress.Utils;
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
    public partial class Authorization : System.Windows.Controls.Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void BtnJoin_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(TbLogin.Text))
                errors = errors.AppendLine("Укажите логин");
            if (string.IsNullOrEmpty(TbPassword.Password))
                errors = errors.AppendLine("Укажите пароль");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                var UserObj = StudentProgressEntities.GetContext().Users.FirstOrDefault(x => x.Login == TbLogin.Text && x.Password == TbPassword.Password);
                if (UserObj == null)
                {
                    MessageBox.Show("Такого пользователя не существует!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Manager.AuthUser = UserObj;
                    switch (UserObj.ID_Role)
                    {
                        case 2:
                            MessageBox.Show("Здравствуйте, Преподаватель ", "Уведомление",      MessageBoxButton.OK, MessageBoxImage.Information);
                            Manager.MainFrame.Navigate(new MainForm());
                            break;
                        case 3:
                            MessageBox.Show("Здравствуйте, Студент ", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            Manager.MainFrame.Navigate(new MainForm());
                            break;
                        case 1:
                            MessageBox.Show("Здравствуйте, Администратор ", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            Manager.MainFrame.Navigate(new MainForm());
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
            Manager.MainFrame.Navigate(new GuestPage());
        }
    }
}

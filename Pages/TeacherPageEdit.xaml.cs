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
    /// Логика взаимодействия для TeacherPageEdit.xaml
    /// </summary>
    public partial class TeacherPageEdit : Page
    {
        private Teacher _currentTeacher = new Teacher();
        public TeacherPageEdit(Teacher selectedTeacher)
        {
            InitializeComponent();
            if (selectedTeacher != null)
                _currentTeacher = selectedTeacher;

            DataContext = _currentTeacher;
            cmbSubject.ItemsSource = StudentProgressEntities.GetContext().Subject.ToList();
        }

        private void btnSaveTeacher_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentTeacher.Surname == null)
                errors = errors.AppendLine("Укажите фамилию преподавателя");
            if (_currentTeacher.Name == null)
                errors = errors.AppendLine("Укажите имя преподавателя");
            if (_currentTeacher.Patronymic == null)
                errors = errors.AppendLine("Укажите отчество преподавателя");
            if (_currentTeacher.Post== null)
                errors = errors.AppendLine("Укажите должность");
            if (_currentTeacher.Subject == null)
                errors = errors.AppendLine("Укажите номер телефона");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_currentTeacher.ID_Teacher == 0)
                try
                {
                    StudentProgressEntities.GetContext().Teacher.Add(_currentTeacher);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            try
            {
                StudentProgressEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}

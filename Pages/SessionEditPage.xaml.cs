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
    /// Логика взаимодействия для SessionEditPage.xaml
    /// </summary>
    public partial class SessionEditPage : Page
    {
        private Session _currentSession = new Session();
        public SessionEditPage(Session selectedSession)
        {
            InitializeComponent();
            if (selectedSession != null)
                _currentSession = selectedSession;

            DataContext = _currentSession;
            cmbGroup.ItemsSource = StudentProgressEntities.GetContext().Group.ToList();
            cmbStudent.ItemsSource = StudentProgressEntities.GetContext().Student.ToList();
            cmbSubject.ItemsSource = StudentProgressEntities.GetContext().Subject.ToList();
            cmbTeacher.ItemsSource = StudentProgressEntities.GetContext().Teacher.ToList();
        }

        private void btnSaveSession_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentSession.Subject == null)
                errors.AppendLine("Укажите предмет");
            if (_currentSession.Teacher == null)
                errors = errors.AppendLine("Укажите ФИО преподавателя");
            if (_currentSession.Group == null)
                errors = errors.AppendLine("Укажите наименование");
            if (_currentSession.Student == null)
                errors = errors.AppendLine("Укажите ФИО студента");
            if (_currentSession.TypeOfCertification == null)
                errors = errors.AppendLine("Укажите тип");
            if (clndDateOfScore.SelectedDate == null)
                errors = errors.AppendLine("Укажите дату");
            if (_currentSession.Grade == null)
                errors = errors.AppendLine("Укажите оценку");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_currentSession.ID_session == 0)
                try
                {
                    StudentProgressEntities.GetContext().Session.Add(_currentSession);
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

        private void clndDateOfScore_Loaded(object sender, RoutedEventArgs e)
        {
            DatePicker datePicker = sender as DatePicker;

            if (datePicker != null && (datePicker.SelectedDate == null || datePicker.SelectedDate == DateTime.MinValue))
            {
                datePicker.SelectedDate = DateTime.Today;
            }
        }
    }
}

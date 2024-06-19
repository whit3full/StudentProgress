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
    /// Логика взаимодействия для StudentCreateEdit.xaml
    /// </summary>
    public partial class StudentCreateEdit : Page
    {
        private Student _currentStudent = new Student();
        public StudentCreateEdit(Student selectedStudent)
        {
            InitializeComponent();
            if (selectedStudent != null)
                _currentStudent = selectedStudent;
           
            DataContext = _currentStudent;
        }

        private void clndDateOfBirth_Loaded(object sender, RoutedEventArgs e)
        {
            DatePicker datePicker = sender as DatePicker;

            if (datePicker != null && (datePicker.SelectedDate == null || datePicker.SelectedDate == DateTime.MinValue))
            {
                datePicker.SelectedDate = DateTime.Today;
            }
        }

        private void btnSaveStudent_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentStudent.Surname == null)
                errors = errors.AppendLine("Укажите фамилию студента");
            if (_currentStudent.Name == null)
                errors = errors.AppendLine("Укажите имя студента");
            if (_currentStudent.Patronymic == null)
                errors = errors.AppendLine("Укажите отчество студента");
            if (clndDateOfBirth.SelectedDate == null)
                errors = errors.AppendLine("Укажите дату");
            if (_currentStudent.NumberPhone == null)
                errors = errors.AppendLine("Укажите номер телефона");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_currentStudent.ID_Student == 0)
                try
                {
                    StudentProgressEntities.GetContext().Student.Add(_currentStudent);
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

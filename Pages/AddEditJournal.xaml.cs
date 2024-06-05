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
    /// Логика взаимодействия для AddEditJournal.xaml
    /// </summary>
    public partial class AddEditJournal
    {
        private Journal _currentJournal = new Journal();

        public AddEditJournal(Journal selectedJournal)
        {
            InitializeComponent();
            if (selectedJournal != null)
                _currentJournal = selectedJournal;

            DataContext = _currentJournal;
            cmbGroup.ItemsSource = StudentProgressEntities.GetContext().Group.ToList();
            cmbStudent.ItemsSource = StudentProgressEntities.GetContext().Student.ToList();
            cmbSubject.ItemsSource = StudentProgressEntities.GetContext().Subject.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentJournal.Subject == null)
                errors.AppendLine("Укажите предмет");
            if (_currentJournal.Group == null)
                errors = errors.AppendLine("Укажите курс");
            if (_currentJournal.Student == null)
                errors = errors.AppendLine("Укажите ФИО студента");
            if (clndDateOfScore.SelectedDate == null)
                errors = errors.AppendLine("Укажите дату");
            if (_currentJournal.Grade == null)
                errors = errors.AppendLine("Укажите оценку");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_currentJournal.ID_Journal == 0)
                try
                {
                    StudentProgressEntities.GetContext().Journal.Add(_currentJournal);
                }
                catch(Exception  ex)
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

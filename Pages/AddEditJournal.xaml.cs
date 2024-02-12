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
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentJournal.ID_Subject <= 0)
                errors.AppendLine("Укажите предмет");
            if (string.IsNullOrWhiteSpace(_currentJournal.Group.Course))
                errors = errors.AppendLine("Укажите курс");
            if (string.IsNullOrWhiteSpace(_currentJournal.Student.FullName))
                errors = errors.AppendLine("Укажите ФИО студента");
            if (clndDateOfScore.SelectedDate == null)
                errors = errors.AppendLine("Укажите дату");
            if (string.IsNullOrWhiteSpace(_currentJournal.Grade))
                errors = errors.AppendLine("Укажите оценку");

            if (_currentJournal.ID_Journal == 0)
                StudentProgressEntities.GetContext().Journal.Add(_currentJournal);
            try
            {
                StudentProgressEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.SubForm.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}

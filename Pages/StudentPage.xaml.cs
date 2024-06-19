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
    /// Логика взаимодействия для StudentPage.xaml
    /// </summary>
    public partial class StudentPage : Page
    {
        public StudentPage()
        {
            InitializeComponent();
            DgStudent.ItemsSource = StudentProgressEntities.GetContext().Student.ToList();
        }

        private void CreateBtnStudent_Click(object sender, RoutedEventArgs e)
        {
            Manager.SubForm.Navigate(new StudentCreateEdit(null));
        }

        private void EditBtnStudent_Click(object sender, RoutedEventArgs e)
        {
            var ObjectForEdit = DgStudent.SelectedItem;
            Manager.SubForm.Navigate(new StudentCreateEdit((Student)ObjectForEdit));

        }

        private void DeleteBtnStudent_Click(object sender, RoutedEventArgs e)
        {
            var StudentForDelete = DgStudent.SelectedItems.Cast<Student>().ToList();
            if (MessageBox.Show($"Вы действительно хотите удалить {StudentForDelete.Count()} элемент",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    StudentProgressEntities.GetContext().Student.RemoveRange(StudentForDelete);
                    StudentProgressEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DgStudent.ItemsSource = StudentProgressEntities.GetContext().Journal.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }
    }
}

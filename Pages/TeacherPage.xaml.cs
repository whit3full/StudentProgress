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
    /// Логика взаимодействия для TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {
        public TeacherPage()
        {
            InitializeComponent();
            DgTeacher.ItemsSource = StudentProgressEntities.GetContext().Teacher.ToList();
        }

        private void CreateBtnTeacher_Click(object sender, RoutedEventArgs e)
        {
            Manager.SubForm.Navigate(new TeacherPageEdit(null));
        }

        private void EditBtnTeacher_Click(object sender, RoutedEventArgs e)
        {
            var ObjectForEdit = DgTeacher.SelectedItem;
            Manager.SubForm.Navigate(new TeacherPageEdit((Teacher)ObjectForEdit));
        }

        private void DeleteBtnTeacher_Click(object sender, RoutedEventArgs e)
        {
            var StudentForDelete = DgTeacher.SelectedItems.Cast<Teacher>().ToList();
            if (MessageBox.Show($"Вы действительно хотите удалить {StudentForDelete.Count()} элемент",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    StudentProgressEntities.GetContext().Teacher.RemoveRange(StudentForDelete);
                    StudentProgressEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DgTeacher.ItemsSource = StudentProgressEntities.GetContext().Teacher.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                StudentProgressEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DgTeacher.ItemsSource = StudentProgressEntities.GetContext().Teacher.ToList();
            }
        }
    }
}

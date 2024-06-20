using StudentProgress.Model;
using StudentProgress.Pages;
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
    /// Логика взаимодействия для SessionPage.xaml
    /// </summary>
    public partial class SessionPage : Page
    {
        public SessionPage()
        {
            InitializeComponent();
            DgSession.ItemsSource = StudentProgressEntities.GetContext().Session.ToList();
        }

        private void DeleteBtnSession_Click(object sender, RoutedEventArgs e)
        {
            var SessionForDelete = DgSession.SelectedItems.Cast<Session>().ToList();
            if (MessageBox.Show($"Вы действительно хотите удалить {SessionForDelete.Count()} элемент",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    StudentProgressEntities.GetContext().Session.RemoveRange(SessionForDelete);
                    StudentProgressEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DgSession.ItemsSource = StudentProgressEntities.GetContext().Session.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }


            }
        }
        private void EditBtnSession_Click(object sender, RoutedEventArgs e)
        {
            var ObjectForEdit = DgSession.SelectedItem;
            Manager.SubForm.Navigate(new SessionEditPage((Session)ObjectForEdit));
        }

        private void CreateBtnSession_Click(object sender, RoutedEventArgs e)
        {
            Manager.SubForm.Navigate(new SessionEditPage(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                StudentProgressEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DgSession.ItemsSource = StudentProgressEntities.GetContext().Session.ToList();
            }
        }
    }
}

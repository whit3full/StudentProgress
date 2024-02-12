using StudentProgress.Utils;
using StudentProgress.Model;
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
    /// Логика взаимодействия для PageJournal.xaml
    /// </summary>
    public partial class PageJournal : Page
    {
        public PageJournal()
        {
            InitializeComponent();
            DgJournal.ItemsSource = StudentProgressEntities.GetContext().Journal.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var ObjectForEdit = DgJournal.SelectedItem;
            Manager.SubForm.Navigate(new AddEditJournal((Journal)ObjectForEdit));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var ObjectForDelete = DgJournal.SelectedItems.Cast<Journal>().ToList();
            if(MessageBox.Show($"Вы действительно хотите удалить {ObjectForDelete.Count()} элемент", 
                "Внимание",MessageBoxButton.YesNo, MessageBoxImage.Question)== MessageBoxResult.Yes)
            {
                try
                {
                    StudentProgressEntities.GetContext().Journal.RemoveRange(ObjectForDelete);
                    StudentProgressEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DgJournal.ItemsSource = StudentProgressEntities.GetContext().Journal.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.SubForm.Navigate(new AddEditJournal(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                StudentProgressEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DgJournal.ItemsSource = StudentProgressEntities.GetContext().Journal.ToList();
            }
        }
    }
}

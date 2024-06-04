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
    public partial class MainForm : Page
    {

        public MainForm()
        {
            InitializeComponent();
            Manager.SubForm = SubForm;
            if(Manager.AuthUser.ID_Role == 2)
            {
                btnStudent.Visibility = Visibility.Visible;
                btnGroup.Visibility = Visibility.Visible;
                btnJournal.Visibility = Visibility.Visible;
                btnSession.Visibility = Visibility.Visible;

            }
            else  if (Manager.AuthUser.ID_Role == 3)
            {
                btnSchedule.Visibility = Visibility.Visible;
                btnJournalStudent.Visibility= Visibility.Visible;

            }
            else if (Manager.AuthUser.ID_Role == 1)
            {
                btnSchedule.Visibility = Visibility.Visible;
                btnJournalStudent.Visibility = Visibility.Visible;
                btnStudent.Visibility = Visibility.Visible;
                btnGroup.Visibility = Visibility.Visible;
                btnJournal.Visibility = Visibility.Visible;
                btnSession.Visibility = Visibility.Visible;
                btnSubject.Visibility = Visibility.Visible;
                btnTeachers.Visibility = Visibility.Visible;
            }
            else  
            {
                btnStudent.Visibility = Visibility.Visible;
                btnGroup.Visibility = Visibility.Visible;
                btnSchedule.Visibility = Visibility.Visible;
                btnJournal.Visibility = Visibility.Visible;
                btnSession.Visibility = Visibility.Visible;
            }
        }

        private void Items_Click(object sender, RoutedEventArgs e)
        {
            Manager.SubForm.Navigate(new TeacherPage());
        }

        private void Group_Click(object sender, RoutedEventArgs e)
        {
            Manager.SubForm.Navigate(new GroupPage());
        }

        private void Student_Click(object sender, RoutedEventArgs e)
        {
            Manager.SubForm.Navigate(new Student());
        }

        private void Session_Click(object sender, RoutedEventArgs e)
        {
            Manager.SubForm.Navigate(new Session());
        }

        private void Journal_Click(object sender, RoutedEventArgs e)
        {
            Manager.SubForm.Navigate(new PageJournal());
        }

        private void btnSchedule_Click(object sender, RoutedEventArgs e)
        {
            Manager.SubForm.Navigate(new PageSchedule());
        }

        private void btnSubject_Click(object sender, RoutedEventArgs e)
        {
            Manager.SubForm.Navigate(new ItemsPage());
        }

        private void btnJournalStudent_Click(object sender, RoutedEventArgs e)
        {
            Manager.SubForm.Navigate(new PageStudentJournal());
        }
    }
}

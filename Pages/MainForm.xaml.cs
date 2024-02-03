using StudentProgress.ApplicationData;
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
    /// Сделать форму которая, будет с дроп меню, где можно выбрать студента, предмет и выставить ему оценку.
    /// <summary>
    /// Логика взаимодействия для MainForm.xaml
    /// </summary>
    public partial class MainForm : Page
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Items_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Group_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Student_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MainFrameForm = FrameForm;
            FrameForm.Navigate(new Student());
        }

        private void Session_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MainFrameForm = FrameForm;
            FrameForm.Navigate(new Session());
        }

        private void Journal_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

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
    /// <summary>
    /// Логика взаимодействия для MainFormTeacher.xaml
    /// </summary>
    public partial class MainFormTeacher : Page
    {
        public MainFormTeacher()
        {
            InitializeComponent();
        }

        private void BtnSchedule_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FormTeacher = FrameFormTeacher;
            FrameFormTeacher.Navigate(new PageSchedule());
        }

        private void BtnItems_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FormTeacher = FrameFormTeacher;
            FrameFormTeacher.Navigate(new ItemsPage());
        }

        private void Journal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Student_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

using StudentProgress.ApplicationData;
using StudentProgress.Pages;
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

namespace StudentProgress
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            AppFrame.MainFrame = FrameMain;
            FrameMain.Navigate(new Authorization());
        }

        private void ButBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MainFrame.GoBack();
        }

        private void FrameMain_ContentRendered(object sender, EventArgs e)
        {
            if (FrameMain.CanGoBack)
            {
                ButBack.Visibility = Visibility.Visible;
            }
            else
            {
                ButBack.Visibility = Visibility.Hidden;
            }
        }
    }
}

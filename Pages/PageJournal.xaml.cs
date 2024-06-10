using StudentProgress.Utils;
using Excel = Microsoft.Office.Interop.Excel;
using StudentProgress.Model;
using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
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
using System.Runtime.InteropServices;

namespace StudentProgress.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageJournal.xaml
    /// </summary>
    [ComVisible(true)]
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
       
        private void BtnSaveExcel_Click(object sender, RoutedEventArgs e)
        {
            // Получаем данные из DataGrid
            var dataGrid = (DataGrid)this.FindName("DgJournal");
            var data = dataGrid.ItemsSource;

            // Создаем экземпляр Excel.Application
            var excelApp = new Excel.Application();

            // Создаем новый Excel-файл
            var workbook = excelApp.Workbooks.Add();
            var worksheet = (Excel.Worksheet)workbook.ActiveSheet;

            // Определяем стиль для заголовков
            var headerStyle = worksheet.get_Range("A1", "A1").Font;
            headerStyle.Bold = true;

            // Экспортируем данные в Excel
            int row = 1;
            foreach (var item in data)
            {
                var properties = item.GetType().GetProperties();
                for (int col = 0; col < properties.Length; col++)
                {
                    worksheet.Cells[row, col + 1] = properties[col].GetValue(item);
                }
                row++;
            }

            // Добавляем заголовки
            row = 1;
            foreach (var property in dataGrid.Columns)
            {
                worksheet.Cells[row, property.DisplayIndex + 1] = property.Header;
            }

            // Сохраняем файл
            string filePath = @"C:\ExportedData.xlsx";
            workbook.SaveAs(filePath, Excel.XlFileFormat.xlOpenXMLWorkbook);

            // Закрываем Excel.Application
            excelApp.Quit();

            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(excelApp);

            MessageBox.Show("Данные экспортированы в файл " + filePath, "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

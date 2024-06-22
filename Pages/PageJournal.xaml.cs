using StudentProgress.Utils;
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
using Microsoft.Win32;
using Excel = Microsoft.Office.Interop.Excel;




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

            var allGroups = StudentProgressEntities.GetContext().Group.ToList();
            allGroups.Insert(0, new Group
            {
                Name = "Все группы"
            });
            cmbGroup.ItemsSource = allGroups;
            cmbGroup.SelectedIndex = 0;
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
                FilterJournalData();
            }
        }

        private void BtnSaveExcel_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel files (*.xlsx)|*.xlsx",
                FilterIndex = 2,
                RestoreDirectory = true,
                FileName = "Journal.xlsx"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                var filePath = saveFileDialog.FileName;

                try
                {
                    var excelApp = new Excel.Application();
                    excelApp.Visible = false;

                    var workbook = excelApp.Workbooks.Add();
                    var worksheet = workbook.Sheets[1] as Excel.Worksheet;

                    // Заголовки
                    worksheet.Cells[1, 1] = "Предмет";
                    worksheet.Cells[1, 2] = "Курс учащегося";
                    worksheet.Cells[1, 3] = "ФИО Студента";
                    worksheet.Cells[1, 4] = "Дата выставления оценки";
                    worksheet.Cells[1, 5] = "Оценка учащегося";

                    // Данные
                    var journalData = DgJournal.ItemsSource as List<Journal>;
                    if (journalData != null)
                    {
                        for (int i = 0; i < journalData.Count; i++)
                        {
                            var row = i + 2;
                            worksheet.Cells[row, 1] = journalData[i].Subject.SubjectName;
                            worksheet.Cells[row, 2] = journalData[i].Group.Course;
                            worksheet.Cells[row, 3] = journalData[i].Student.FullName;
                            worksheet.Cells[row, 4] = journalData[i].Date.ToString("d");
                            worksheet.Cells[row, 5] = journalData[i].Grade;
                        }

                        // Форматирование
                        var headerRange = worksheet.Range["A1", "E1"];
                        headerRange.Font.Bold = true;
                        headerRange.Interior.Color = Excel.XlRgbColor.rgbLightGray;
                        worksheet.Columns.AutoFit();
                    }

                    // Сохранение файла
                    workbook.SaveAs(filePath);
                    workbook.Close();
                    excelApp.Quit();

                    MessageBox.Show("Файл успешно сохранен", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void cmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterJournalData();
        }
        private void FilterJournalData()
        {
            var selectedGroup = cmbGroup.SelectedItem as Group;
            if (selectedGroup != null)
            {
                if (selectedGroup.Name == "Все группы")
                {
                    DgJournal.ItemsSource = StudentProgressEntities.GetContext().Journal.ToList();
                }
                else
                {
                    DgJournal.ItemsSource = StudentProgressEntities.GetContext().Journal
                        .Where(j => j.Group.Name == selectedGroup.Name)
                        .ToList();
                }
            }
        }
    }
}

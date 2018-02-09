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
using System.Windows.Shapes;

namespace SeventhDay.Windows
{
    /// <summary>
    /// Логика взаимодействия для ChooseVacancyWindow.xaml
    /// </summary>
    public partial class ChooseVacancyWindow : Window
    {
        DB.Entity db = HelpClasses.StaticClass.db;

        public ChooseVacancyWindow()
        {
            InitializeComponent();

            sp.DataContext = HelpClasses.StaticClass.SelectVacancy;

            cbxJobless.ItemsSource = db.Jobless.Where(w=>w.Used == true).ToList();
            cbxJobless.DisplayMemberPath = "FullName";
            cbxJobless.SelectedIndex = 0;
        }

        private void click_Back(object sender, RoutedEventArgs e)
        {
            new VacanciesWindow().Show();
            this.Close();
        }

        private void select_cbxJobless(object sender, SelectionChangedEventArgs e)
        {
            imgJobless.DataContext = (DB.Jobless)((ComboBox)sender).SelectedItem;
        }

        private void click_Save(object sender, RoutedEventArgs e)
        {
            var client = (DB.Jobless)cbxJobless.SelectedItem;
            client.Used = false;
            HelpClasses.StaticClass.SelectVacancy.Used = false;

            db.Archives.Add(new DB.Archives {
                Jobless = client,
                Users = HelpClasses.StaticClass.AuthUser,
                Vacancies = HelpClasses.StaticClass.SelectVacancy,
                ArchivesDate = DateTime.Now
            });
            
            db.SaveChanges();

            MessageBox.Show("Клиент обрёл место работы!","Perfect",MessageBoxButton.OK,MessageBoxImage.Information);
            new VacanciesWindow().Show();
            this.Close();
        }
    }
}

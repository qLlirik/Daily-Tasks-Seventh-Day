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
    /// Логика взаимодействия для AddNewVacancyWindow.xaml
    /// </summary>
    public partial class AddNewVacancyWindow : Window
    {
        DB.Entity db = HelpClasses.StaticClass.db;
        public AddNewVacancyWindow()
        {
            InitializeComponent();
        }

        private void click_AddNewVacancy(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((tbxOrganizationName.Text.Length == 0) || (tbxOrganizationAddress.Text.Length == 0) || (tbxOrganizationPhone.Text.Length == 0) || (tbxVacancyName.Text.Length == 0) || (tbxPrice.Text.Length == 0))
                {
                    throw new System.FormatException();
                }

                db.Vacancies.Add(new DB.Vacancies {
                    OrganizationName = tbxOrganizationName.Text,
                    OrganizationAddress = tbxOrganizationAddress.Text,
                    OrganizationPhone = tbxOrganizationPhone.Text,
                    VacancyName = tbxVacancyName.Text,
                    Price = decimal.Parse(tbxPrice.Text),
                    More = tbxMore.Text.Length == 0 ? null : tbxMore.Text 
                });
                db.SaveChanges();

                if (MessageBox.Show("Вакансия добавлена! Хотите добавить ещё?","Perfect",MessageBoxButton.YesNo,MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    new AddNewVacancyWindow().Show();
                    this.Close();
                }
                else
                {
                    click_Back(null,null);
                }
            }
            catch
            {
                MessageBox.Show("Введите корректные данные!","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void click_Back(object sender, RoutedEventArgs e)
        {
            new VacanciesWindow().Show();
            this.Close();
        }
    }
}

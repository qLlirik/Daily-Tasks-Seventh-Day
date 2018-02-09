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
    /// Логика взаимодействия для VacanciesWindow.xaml
    /// </summary>
    public partial class VacanciesWindow : Window
    {
        DB.Entity db = HelpClasses.StaticClass.db;
        Brush[] colors = new Brush[] { Brushes.LightCoral, Brushes.LightBlue, Brushes.LightCyan, Brushes.LightGoldenrodYellow, Brushes.LightGray, Brushes.LightGreen, Brushes.LightPink, Brushes.LightSalmon, Brushes.LightSeaGreen, Brushes.LightSlateGray, Brushes.LightSteelBlue, Brushes.LightYellow };

        public VacanciesWindow()
        {
            InitializeComponent();
            click_Search(null,null);
            
        }

        private void click_Back(object sender, RoutedEventArgs e)
        {
            new MainMenuWindow().Show();
            this.Close();
        }

        private void click_AddNewVacancy(object sender, RoutedEventArgs e)
        {
            new AddNewVacancyWindow().Show();
            this.Close();
        }

        private void click_Search(object sender, RoutedEventArgs e)
        {
            var qwery = db.Vacancies.Where(w => w.OrganizationName.Length != 0);
            if (tbxSearch.Text.Length != 0)
            {
                qwery = qwery.Where(w => w.VacancyName.Contains(tbxSearch.Text));
            }

            Random r = new Random();
            wp.Children.Clear();
            foreach(var i in qwery.Where(w=>w.Used == true))
            {
                UserControls.VacancyUserControl uc = new UserControls.VacancyUserControl();
                uc.DataContext = i;
                uc.Background = colors[r.Next(colors.Length - 1)];
                uc.Margin = new Thickness(10);
                uc.BorderBrush = Brushes.Black;
                uc.BorderThickness = new Thickness(2);

                uc.MouseLeftButtonDown += Uc_MouseLeftButtonDown;

                wp.Children.Add(uc);
            }
        }

        private void Uc_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HelpClasses.StaticClass.SelectVacancy = (DB.Vacancies)((UserControl)sender).DataContext;
            new ChooseVacancyWindow().Show();
            this.Close();
        }
    }
}

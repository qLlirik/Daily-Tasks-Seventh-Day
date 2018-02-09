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
    /// Логика взаимодействия для MainMenuWindow.xaml
    /// </summary>
    public partial class MainMenuWindow : Window
    {
        public MainMenuWindow()
        {
            InitializeComponent();

            tbxUserName.Text = "Здравствуйте, " + HelpClasses.StaticClass.AuthUser.FullName;
        }

        private void clickLogout(object sender, RoutedEventArgs e)
        {
            HelpClasses.StaticClass.AuthUser = null;
            new MainWindow().Show();
            this.Close();
        }

        private void click_Vacancies(object sender, RoutedEventArgs e)
        {
            new VacanciesWindow().Show();
            this.Close();
        }
    }
}

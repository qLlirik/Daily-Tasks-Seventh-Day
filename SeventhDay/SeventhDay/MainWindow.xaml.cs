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

namespace SeventhDay
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DB.Entity db = HelpClasses.StaticClass.db;

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                string str = System.IO.File.ReadAllText("RemeberMe.txt");
                if (str != "null")
                {
                    var arr = str.Split('`');
                    tbxLogin.Text = arr.First();
                    pbxPassword.Password = arr.Last();
                    chbxRemberMe.IsChecked = true;
                }
            }
            catch { }
        }

        private void clickAuthorization(object sender, RoutedEventArgs e)
        {
            try
            {
                HelpClasses.StaticClass.AuthUser = db.Users.ToList().First(w => w.Login == tbxLogin.Text && w.Password == pbxPassword.Password);

                if (chbxRemberMe.IsChecked == true)
                {
                    string pass = pbxPassword.Password;
                    System.IO.File.WriteAllText("RemeberMe.txt",tbxLogin.Text + '`' + pass);
                }
                else
                    System.IO.File.WriteAllText("RemeberMe.txt", "null");
                new Windows.MainMenuWindow().Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Такой пользователь не найден!","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void keydown_PAssword(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                clickAuthorization(null,null);
        }

        private void keydawn_Login(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                clickAuthorization(null, null);
        }
    }
}

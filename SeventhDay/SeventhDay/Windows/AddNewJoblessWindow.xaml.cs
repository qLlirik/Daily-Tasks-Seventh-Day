using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddNewJoblessWindow.xaml
    /// </summary>
    public partial class AddNewJoblessWindow : Window
    {
        DB.Entity db = HelpClasses.StaticClass.db;

        public AddNewJoblessWindow()
        {
            InitializeComponent();

            cbxStudyType.ItemsSource = db.StudyTypies.ToList();
            cbxStudyType.DisplayMemberPath = "Name";
            cbxStudyType.SelectedIndex = 0;

            dpPassportDate.SelectedDate = DateTime.Now;
        }

        private void click_Back(object sender, RoutedEventArgs e)
        {
            new MainMenuWindow().Show();
            this.Close();
        }

        private void click_SelectImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All Images|*.png;*.bmp;*.jpg;*.jpeg";
            if (ofd.ShowDialog() == true)
                tbxImage.Text = ofd.FileName;
        }

        private byte[] ImageToByte(string uri)
        {
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(new BitmapImage(new Uri(uri, UriKind.Relative))));
            MemoryStream ms = new MemoryStream();
            encoder.Save(ms);
            return ms.ToArray();
        }

        private void click_AddNewJobless(object sender, RoutedEventArgs e)
        {
            try
            {
              var FullName = tbxFullName.Text.Split(' ');
              db.Jobless.Add(new DB.Jobless
              {
                  LastName = FullName[0],
                  FirstName = FullName[1],
                  Patronymic = FullName[2],
                  Age = byte.Parse(tbxAge.Text),
                  Passport = tbxPassport.Text,
                  PassportDate = dpPassportDate.SelectedDate.Value,
                  Region = tbxRegion.Text,
                  Address = tbxAddress.Text,
                  Phone = tbxPhone.Text,
                  Picture = ImageToByte(tbxImage.Text),
                  StudyPlace = tbxStudyPlace.Text,
                  StudyAddress = tbxStudyAddress.Text,
                  StudyTypies = (DB.StudyTypies)cbxStudyType.SelectedItem,
                  RegistratorID = HelpClasses.StaticClass.AuthUser.ID,
                  RegDate = DateTime.Now,
                  Payment = decimal.Parse(tbxPayment.Text),
                  Experience = chbxExperience.IsChecked == true ? true : false,
                  Comment = tbxComment.Text.Length == 0 ? null : tbxComment.Text
              });
              db.SaveChanges();

              if (MessageBox.Show("Добавление безработного в учёт прошло успешно!", "Perfect", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
              {
                  new AddNewJoblessWindow().Show();
                  this.Close();
              }
              else
                  click_Back(null, null);
            }
            catch
            {
                MessageBox.Show("Введите корректные данные!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

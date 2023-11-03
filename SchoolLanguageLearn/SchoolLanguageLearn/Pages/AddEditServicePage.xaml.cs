using Microsoft.Win32;
using SchoolLanguageLearn.Components;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolLanguageLearn.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditServicePage.xaml
    /// </summary>
    public partial class AddEditServicePage : Page
    {
        private Service service;
        public AddEditServicePage(Service _service)
        {
            InitializeComponent();
            service = _service;
            this.DataContext = service;
            RefreshPhoto();
        }

        private void EditImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg*|*.jpeg|*.jpeg"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                service.MainImage = File.ReadAllBytes(openFile.FileName);
                MainImage.Source = new BitmapImage(new Uri(openFile.FileName));
            }

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {StringBuilder errors = new StringBuilder();
            if(service.ID == 0)
            {
                if(App.db.Service.Any(x => x.Title== service.Title))
                {
                    errors.AppendLine("Такая услуга уже существует!");
                }
                else
                {
                    App.db.Service.Add(service);
                }
            }
            if(service.DurationInSeconds > 14400)
            {
                errors.AppendLine("Длительность не может привышать больше 4 часов");
            }
            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
            }
            else
            {
                App.db.SaveChanges();
                MessageBox.Show("Сохранено");
                Navigation.NextPage(new PageComponent("Список услуг", new ServicesListPage()));
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(char.IsDigit(e.Text[0]))) //(char.Parse(e.Text))
            {
                e.Handled = true;
            }
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg*|*.jpeg|*.jpeg"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                App.db.ServicePhoto.Add(new ServicePhoto
                {
                    ServiceID = service.ID,
                    PhotoByte = File.ReadAllBytes(openFile.FileName)
                });
                App.db.SaveChanges();
                RefreshPhoto();
            }
        }
        private void RefreshPhoto()
        {
            foreach (var photo in service.ServicePhoto)
            {
                PhotoWp.Children.Add(new PhotoUserControl1(photo));
            }
        }
    }
}

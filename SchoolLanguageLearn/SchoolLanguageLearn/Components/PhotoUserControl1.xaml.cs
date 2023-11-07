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

namespace SchoolLanguageLearn.Components
{
    /// <summary>
    /// Логика взаимодействия для PhotoUserControl1.xaml
    /// </summary>
    public partial class PhotoUserControl1 : UserControl
    {
        ServicePhoto servicePhoto;
        public PhotoUserControl1(ServicePhoto _servicePhoto)
        {
            InitializeComponent();
            //App.servicePage = this;
            servicePhoto = _servicePhoto;
            this.DataContext = servicePhoto;
        }

        private void MainBtbn_Click(object sender, RoutedEventArgs e)
        {
            var selPhoto = servicePhoto.PhotoByte;
            servicePhoto.PhotoByte = servicePhoto.Service.MainImage;
            servicePhoto.Service.MainImage = selPhoto;
            App.servicePage.RefreshPhoto();
            App.db.SaveChanges();
        }

        private void DeletBtbn_Click(object sender, RoutedEventArgs e)
        {
            App.db.ServicePhoto.Remove(servicePhoto);
            App.servicePage.RefreshPhoto();
            App.db.SaveChanges();

        }
    }
}

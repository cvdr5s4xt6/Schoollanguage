using SchoolLanguageLearn.Components;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolLanguageLearn
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static LanguaheSchool322Entities db = new LanguaheSchool322Entities();
        public static bool isAdmin = false;
        public static MainWindow mainWindow;
    }
}

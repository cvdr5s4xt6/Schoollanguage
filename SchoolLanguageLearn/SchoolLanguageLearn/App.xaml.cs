﻿using SchoolLanguageLearn.Components;
using SchoolLanguageLearn.Pages;
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
        public static LanguaheSchoollEntities db = new LanguaheSchoollEntities();
        public static bool isAdmin = false;
        public static MainWindow mainWindow;
        public static AddEditServicePage servicePage;
    }
}

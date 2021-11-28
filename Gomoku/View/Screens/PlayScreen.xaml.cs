using Model.Gomoku;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel;

namespace View.Screens
{
    /// <summary>
    /// Interaction logic for PlayScreen.xaml
    /// </summary>
    public partial class PlayScreen : UserControl
    {
        public PlayScreen()
        {
            InitializeComponent();

        }

        private string currentTheme = "Light";

        private void ChangeTheme(object sender, RoutedEventArgs e)
        {
            if(this.currentTheme == "Dark")
            {
                SetTheme("Light");
                this.currentTheme = "Light";
            }
            else if (this.currentTheme == "Light")
            {
                SetTheme("Dark");
                this.currentTheme = "Dark";
            }
        }

        private void SetTheme(string name)
        {
            var app = (App)Application.Current;
            app.SetTheme(name);
        }
    }

}

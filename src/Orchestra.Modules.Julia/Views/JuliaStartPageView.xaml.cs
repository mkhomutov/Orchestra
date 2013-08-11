using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Orchestra.Modules.Julia.Views
{
    using Orchestra.Modules.Julia.Views.Interfaces;
    using Orchestra.Views;

    /// <summary>
    /// Логика взаимодействия для JuliaStartPage.xaml
    /// </summary>
    public partial class JuliaStartPageView : DocumentView, IJuliaStartPageView
    {
        public JuliaStartPageView()
        {
            InitializeComponent();
        }
    }
}

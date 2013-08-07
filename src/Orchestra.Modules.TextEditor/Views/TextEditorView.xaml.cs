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

namespace Orchestra.Modules.JuliaEditor.Views
{
    using Orchestra.Views;

    /// <summary>
    /// Interaction logic for JuliaLangEditorView.xaml.
    /// </summary>
    public partial class TextEditorView : DocumentView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextEditorView"/> class.
        /// </summary>
        public TextEditorView()
        {
            InitializeComponent();
        }
    }
}

namespace Orchestra.Modules.TextEditor.Views
{
    using Orchestra.Modules.TextEditor.Views.Interfaces;
    using Orchestra.Views;

    /// <summary>
    /// Interaction logic for JuliaLangEditorView.xaml.
    /// </summary>
    public partial class TextEditorView : DocumentView, ITextEditorView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextEditorView"/> class.
        /// </summary>
        public TextEditorView()
        {            
            this.InitializeComponent();
        }

    }
}

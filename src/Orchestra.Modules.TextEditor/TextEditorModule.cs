namespace Orchestra.Modules.TextEditor
{
    using Orchestra.Modules.TextEditor.Services;
    using Orchestra.Modules.TextEditor.Services.Interfaces;

    /// <summary>
    /// The module.
    /// </summary>
    public class TextEditorModule : Orchestra.Modules.ModuleBase
    {
        /// <summary>
        /// Initializes the module.
        /// </summary>
        public TextEditorModule()
            : base("TextEditorModule")
        {
        }

        /// <summary>
        /// Called when the module is initialized.
        /// </summary>
        protected override void OnInitialized()
        {
            Catel.IoC.ServiceLocator.Default.RegisterInstance(typeof(ITextEditorManager), new TextEditorManager());
        }
    }
}
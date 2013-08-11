namespace Orchestra.Modules.TextEditor
{
    using System.Collections.Generic;
    using System.Linq;
    using Catel.Messaging;
    using Orchestra.Modules.TextEditor.Helpers;
    using Orchestra.Modules.TextEditor.Models;
    using Orchestra.Modules.TextEditor.Services;
    using Orchestra.Modules.TextEditor.Services.Interfaces;
    using Orchestra.Modules.TextEditor.ViewModels;

    /// <summary>
    /// The module.
    /// </summary>
    public class TextEditorModule : Orchestra.Modules.ModuleBase
    {
        private readonly IDictionary<string, TextEditorConfiguration> _configurations = new Dictionary<string, TextEditorConfiguration>();

        private readonly IDictionary<Document, TextEditorViewModel> _documents = new Dictionary<Document, TextEditorViewModel>();

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
            Catel.IoC.ServiceLocator.Default.RegisterInstance(typeof(ITextEditorService), new TextEditorService(this));
            base.OnInitialized();
        }

        public void UpdateConfiguration(TextEditorConfiguration configuration)
        {
            if (_configurations.ContainsKey(configuration.ConfigurationName))
            {
                _configurations.Remove(configuration.ConfigurationName);
            }

            _configurations.Add(configuration.ConfigurationName, configuration);

            foreach (var document in _documents.Select(x => x.Key).Where(x => x.ConfigurationName == configuration.ConfigurationName))
            {
                document.ApplyConfiguration(configuration);
            }
        }

        internal IEnumerable<Document> GetDocuments()
        {
            return _documents.Select(x => x.Key);
        }

        internal void AddDocument(TextEditorViewModel textEditorViewModel)
        {
            _documents.Add(textEditorViewModel.Document, textEditorViewModel);
            textEditorViewModel.Document.ApplyConfiguration(_configurations[textEditorViewModel.Document.ConfigurationName]);
        }
    }
}
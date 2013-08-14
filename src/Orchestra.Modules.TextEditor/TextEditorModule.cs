// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextEditorModule.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor
{
    using System.Collections.Generic;
    using System.Linq;
    using Catel.IoC;
    using Orchestra.Modules.TextEditor.Helpers;
    using Orchestra.Modules.TextEditor.Models;
    using Orchestra.Modules.TextEditor.Services;
    using Orchestra.Modules.TextEditor.Services.Interfaces;
    using Orchestra.Modules.TextEditor.ViewModels;

    /// <summary>
    /// The module.
    /// </summary>
    public class TextEditorModule : ModuleBase
    {
        #region Fields
        private readonly IDictionary<string, TextEditorConfiguration> _configurations = new Dictionary<string, TextEditorConfiguration>();

        private readonly IDictionary<Document, TextEditorViewModel> _documents = new Dictionary<Document, TextEditorViewModel>();
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes the module.
        /// </summary>
        public TextEditorModule()
            : base("TextEditorModule")
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Called when the module is initialized.
        /// </summary>
        protected override void OnInitialized()
        {
            ServiceLocator.Default.RegisterInstance(typeof (ITextEditorService), new TextEditorService(this));
            ServiceLocator.Default.RegisterInstance(typeof(IDocumentService), new DocumentService());
            base.OnInitialized();
        }

        public void AddConfiguration(TextEditorConfiguration configuration)
        {
            if (_configurations.ContainsKey(configuration.Name))
            {
                _configurations.Remove(configuration.Name);
            }

            _configurations.Add(configuration.Name, configuration);
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
        #endregion

        public TextEditorConfiguration GetConfigurationByName(string configurationName)
        {
            return _configurations[configurationName];
        }
    }
}
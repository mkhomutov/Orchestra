// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextEditorModule.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor
{
    using System.Collections.Generic;
    using System.Linq;
    using Orchestra.Modules.TextEditor.Interfaces;
    using Orchestra.Modules.TextEditor.Models;
    using Orchestra.Modules.TextEditor.Models.Interfaces;
    using Orchestra.Modules.TextEditor.ViewModels.Interfaces;
    using Orchestra.Services;

    /// <summary>
    /// The module.
    /// </summary>
    public class TextEditorModule : ModuleBase, ITextEditorModule
    {
        #region Fields
        private readonly IConfigurationsStorage _configurations;

        private readonly IDocumentsStorage _documents;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes the module.
        /// </summary>
        public TextEditorModule(IDocumentsStorage documents, IConfigurationsStorage configurations, IRibbonService ribbonService)
            : base("TextEditorModule", ribbonService)
        {
            _documents = documents;
            _configurations = configurations;
        }
        #endregion

        #region ITextEditorModule Members
        public void ApplyConfiguration(ITextEditorConfiguration configuration)
        {
            if (_configurations.Existed(configuration))
            {
                _configurations.Replace(configuration);
            }
            else
            {
                _configurations.Add(configuration);
            }
        }

        public IEnumerable<IDocument> GetDocuments()
        {
            return _documents.GetAll()
                             .Select(x => x.Document);
        }

        public void AddDocument(ITextEditorViewModel textEditorViewModel)
        {
            _documents.Add(textEditorViewModel);
        }

        public IEnumerable<ITextEditorConfiguration> GetConfigurations()
        {
            return _configurations.GetAll();
        }
        #endregion
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextEditorService.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using ICSharpCode.AvalonEdit.Highlighting;
    using ICSharpCode.AvalonEdit.Highlighting.Xshd;
    using Orchestra.Modules.TextEditor.Exceptions;
    using Orchestra.Modules.TextEditor.Models;
    using Orchestra.Modules.TextEditor.Models.Interfaces;
    using Orchestra.Modules.TextEditor.Services.Interfaces;
    using Orchestra.Modules.TextEditor.ViewModels;
    using Orchestra.Services;

    public class TextEditorService : ITextEditorService
    {
        #region Fields
        private readonly IOrchestraService _orchestraService;
        private readonly IDocumentsStorage _documents;
        private readonly IConfigurationsStorage _configurations;
        #endregion

        #region Constructors
        public TextEditorService(IOrchestraService orchestraService, IDocumentsStorage documents, IConfigurationsStorage configurations)
        {
            _orchestraService = orchestraService;
            _documents = documents;
            _configurations = configurations;
        }
        #endregion

        #region ITextEditorService Members
        public TextEditorConfigurationBuilder Configure(string configurationName)
        {            
            return new TextEditorConfigurationBuilder(this, new TextEditorConfiguration(),  configurationName);
        }

        public IDocument CreateDocument(string configurationName)
        {
            if (_configurations.GetAll().All(x => x.Name != configurationName))
            {
                throw new ConfigurationNotFoundException(configurationName);
            }

            var doc = new Document {ConfigurationName = configurationName};
            doc.ViewModel = new TextEditorViewModel { Document = doc };
            _documents.Add(doc.ViewModel);

            _orchestraService.ShowDocument(doc.ViewModel, doc);

            return doc;
        }

        public IDocument GetActiveDocument()
        {
            return _documents.GetAll()
                             .Where(x => _orchestraService.IsActive<TextEditorViewModel>(x))
                             .Select(x => x.Document)
                             .FirstOrDefault();
        }

        public void RegisterHighlighting(string schema, params string[] extensions)
        {
            using (var strRead = new StringReader(schema))
            {
                using (XmlReader reader = XmlReader.Create(strRead))
                {
                    XshdSyntaxDefinition xshd = HighlightingLoader.LoadXshd(reader);
                    IHighlightingDefinition hilightning = HighlightingLoader.Load(xshd, new HighlightingManager());

                    HighlightingManager.Instance.RegisterHighlighting(hilightning.Name, extensions, hilightning);
                }
            }
        }

        public IEnumerable<ITextEditorConfiguration> GetConfigurations()
        {
            return _configurations.GetAll();
        }

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

        #endregion
    }
}
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
    using Orchestra.Modules.TextEditor.Interfaces;
    using Orchestra.Modules.TextEditor.Models;
    using Orchestra.Modules.TextEditor.Models.Interfaces;
    using Orchestra.Modules.TextEditor.Services.Interfaces;
    using Orchestra.Modules.TextEditor.ViewModels;
    using Orchestra.Services;

    public class TextEditorService : ITextEditorService
    {
        #region Fields
        private readonly ITextEditorModule _module;
        private readonly IOrchestraService _orchestraService;
        #endregion

        #region Constructors
        public TextEditorService(ITextEditorModule module, IOrchestraService orchestraService)
        {
            _module = module;
            _orchestraService = orchestraService;
        }
        #endregion

        #region ITextEditorService Members
        public TextEditorConfigurationBuilder Configure(string configurationName)
        {            
            return new TextEditorConfigurationBuilder(_module, new TextEditorConfiguration(),  configurationName);
        }

        public IDocument CreateDocument(string configurationName)
        {
            if (_module.GetConfigurations().All(x => x.Name != configurationName))
            {
                throw new ConfigurationNotFoundException(configurationName);
            }

            var viewModel = new TextEditorViewModel {Document = new Document() {ConfigurationName = configurationName}};
            _module.AddDocument(viewModel);

            _orchestraService.ShowDocument(viewModel, viewModel.Document);

            return viewModel.Document;
        }

        public IDocument GetActiveDocument()
        {
            return _module.GetDocuments()
                          .FirstOrDefault(_orchestraService.IsActive<TextEditorViewModel>);
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
            return _module.GetConfigurations();
        }
        #endregion
    }
}
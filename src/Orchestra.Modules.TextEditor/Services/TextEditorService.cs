// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextEditorService.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.Services
{
    using System;
    using System.Linq;
    using Catel.IoC;

    using Orchestra.Modules.TextEditor.Helpers;
    using Orchestra.Modules.TextEditor.Models;
    using Orchestra.Modules.TextEditor.Services.Interfaces;
    using Orchestra.Modules.TextEditor.ViewModels;
    using Orchestra.Services;

    public class TextEditorService : ITextEditorService
    {
        #region Fields
        private readonly TextEditorModule _module;
        #endregion

        #region Constructors
        public TextEditorService(TextEditorModule module)
        {
            _module = module;
        }
        #endregion

        #region ITextEditorService Members
        public TextEditorConfigurationBuilder Configure(string configurationName)
        {
            return new TextEditorConfigurationBuilder(_module, configurationName);
        }

        public Document CreateDocument(string configurationName)
        {
            var viewModel = new TextEditorViewModel {Document = new Document(configurationName)};
            var orchestraService = (IOrchestraService) ServiceLocator.Default.ResolveType(typeof (IOrchestraService));
            _module.AddDocument(viewModel);

            orchestraService.ShowDocument(viewModel, viewModel.Document);

            return viewModel.Document;
        }

        public Document GetActiveDocument()
        {
            var orchestraService = (IOrchestraService) ServiceLocator.Default.ResolveType(typeof (IOrchestraService));
            return _module.GetDocuments()
                          .FirstOrDefault(orchestraService.IsActive<TextEditorViewModel>);
        }

        public void ApplyConfiguration(TextEditorConfiguration confuguration)
        {            
            _module.AddConfiguration(confuguration);

            foreach (var document in _module.GetDocuments().Where(x => x.ConfigurationName == confuguration.Name))
            {
                document.ApplyConfiguration(confuguration);
            }
        }

        public TextEditorConfiguration GetConfigurationByName(string configurationName)
        {
            return _module.GetConfigurationByName(configurationName);
        }
        #endregion
    }
}
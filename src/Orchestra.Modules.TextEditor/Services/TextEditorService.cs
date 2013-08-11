// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextEditorService.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Orchestra.Modules.TextEditor.Services
{
    using System.Linq;
    using Orchestra.Modules.TextEditor.Models;
    using Orchestra.Modules.TextEditor.Services.Interfaces;
    using Orchestra.Modules.TextEditor.ViewModels;
    using Orchestra.Services;

    public class TextEditorService : ITextEditorService
    {
        private TextEditorModule _module;

        public TextEditorService(TextEditorModule module)
        {
            this._module = module;
        }

        public TextEditorConfigurationBuilder Configure(string configurationName)
        {
            return new TextEditorConfigurationBuilder(_module, configurationName);
        }

        public Document CreateDocument(string configurationName)
        {
            var viewModel = new TextEditorViewModel {Document = new Document(configurationName)};
            var orchestraService = (IOrchestraService)Catel.IoC.ServiceLocator.Default.ResolveType(typeof(IOrchestraService));
            _module.AddDocument(viewModel);

            orchestraService.ShowDocument(viewModel, viewModel.Document);
 
            return viewModel.Document;
        }

        public Document GetActiveDocument()
        {
            var orchestraService = (IOrchestraService)Catel.IoC.ServiceLocator.Default.ResolveType(typeof(IOrchestraService));
            return _module.GetDocuments().FirstOrDefault(orchestraService.IsActive<TextEditorViewModel>);           
        }
    }
}
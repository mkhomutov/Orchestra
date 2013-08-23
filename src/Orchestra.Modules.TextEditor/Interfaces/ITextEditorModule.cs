// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITextEditorModule.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.Interfaces
{
    using System.Collections.Generic;
    using Orchestra.Modules.TextEditor.Models;
    using Orchestra.Modules.TextEditor.Models.Interfaces;
    using Orchestra.Modules.TextEditor.ViewModels.Interfaces;

    public interface ITextEditorModule
    {
        #region Methods
        void AddDocument(ITextEditorViewModel viewModel);
        IEnumerable<IDocument> GetDocuments();
        void ApplyConfiguration(ITextEditorConfiguration confuguration);
        IEnumerable<ITextEditorConfiguration> GetConfigurations();
        #endregion
    }
}
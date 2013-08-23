// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDocumentsStorage.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.Models.Interfaces
{
    using System.Collections.Generic;
    using Orchestra.Modules.TextEditor.ViewModels.Interfaces;

    public interface IDocumentsStorage
    {
        #region Methods
        void Add(ITextEditorViewModel documentViewModel);
        IEnumerable<ITextEditorViewModel> GetAll();
        #endregion
    }
}
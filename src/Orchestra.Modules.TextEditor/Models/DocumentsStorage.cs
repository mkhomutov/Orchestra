// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentsStorage.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.Models
{
    using System;
    using System.Collections.Generic;
    using Orchestra.Modules.TextEditor.Models.Interfaces;
    using Orchestra.Modules.TextEditor.ViewModels.Interfaces;

    public class DocumentsStorage : IDocumentsStorage
    {
        #region IDocumentsStorage Members
        public void Add(ITextEditorViewModel documentViewModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITextEditorViewModel> GetAll()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentsStorage.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Orchestra.Modules.TextEditor.Models.Interfaces;
    using Orchestra.Modules.TextEditor.ViewModels.Interfaces;

    public class DocumentsStorage : IDocumentsStorage
    {
        private  IList<ITextEditorViewModel> _documents = new List<ITextEditorViewModel>();
        
        #region IDocumentsStorage Members
        public void Add(ITextEditorViewModel documentViewModel)
        {
            _documents.Add(documentViewModel);
        }

        public IEnumerable<ITextEditorViewModel> GetAll()
        {
            return _documents.AsEnumerable();
        }
        #endregion
    }
}
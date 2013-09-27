// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDocumentService.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.Services.Interfaces
{
    using System.IO;
    using Orchestra.Modules.TextEditor.Models.Interfaces;

    public interface IDocumentService
    {
        #region Methods
        void SetHighlighting(IDocument document, string fileExtension);
        string GetDocumentText(IDocument document);
        void SetDocumentText(IDocument document, string text);
        #endregion
    }
}
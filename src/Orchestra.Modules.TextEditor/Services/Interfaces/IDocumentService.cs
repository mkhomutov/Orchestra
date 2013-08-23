// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDocumentService.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.Services.Interfaces
{
    using Orchestra.Modules.TextEditor.Models.Interfaces;

    public interface IDocumentService
    {
        #region Methods
        void GenerateAndApplyNewFileName(IDocument document, string fileExtension);
        void GetDocumentText(IDocument document);
        void MarkAsSavedToFile(IDocument document, string fileName);
        #endregion
    }
}
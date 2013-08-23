// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentService.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.Services
{
    using ICSharpCode.AvalonEdit.Highlighting;
    using Orchestra.Modules.TextEditor.Helpers;
    using Orchestra.Modules.TextEditor.Models;
    using Orchestra.Modules.TextEditor.Models.Interfaces;
    using Orchestra.Modules.TextEditor.Services.Interfaces;

    public class DocumentService : IDocumentService
    {
        #region IDocumentService Members
        public void GenerateAndApplyNewFileName(IDocument document, string fileExtension)
        {
            ((Document)document).FileName = FileNamesManager.DefaultInstance.GetNexDefaulFileName(fileExtension);
            ((Document)document).CurrentHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(fileExtension);
        }

        public void GetDocumentText(IDocument document)
        {
            throw new System.NotImplementedException();
        }

        public void MarkAsSavedToFile(IDocument document, string fileName)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
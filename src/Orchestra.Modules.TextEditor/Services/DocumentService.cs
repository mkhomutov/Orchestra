// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentService.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.Services
{
    using System.IO;
    using System.Linq;
    using ICSharpCode.AvalonEdit.Highlighting;
    using Orchestra.Modules.TextEditor.Helpers;
    using Orchestra.Modules.TextEditor.Models;
    using Orchestra.Modules.TextEditor.Models.Interfaces;
    using Orchestra.Modules.TextEditor.Services.Interfaces;

    public class DocumentService : IDocumentService
    {
        private readonly ITextEditorService _textEditorService;

        public DocumentService(ITextEditorService textEditorService)
        {
            _textEditorService = textEditorService;
        }

        #region IDocumentService Members
        public void SetHighlighting(IDocument document, string fileExtension)
        {
            ((Document)document).CurrentHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(fileExtension);
        }

        public string GetDocumentText(IDocument document)
        {
            return ((Document)document).ViewModel.GetText();
        }

        public void SetDocumentText(IDocument document, string text)
        {
            ((Document) document).ViewModel.SetText(text);
        }
        #endregion
    }
}
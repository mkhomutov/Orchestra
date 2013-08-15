// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentService.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Orchestra.Modules.TextEditor.Services
{
    using Catel.IoC;

    using ICSharpCode.AvalonEdit.Highlighting;

    using Orchestra.Modules.TextEditor.Helpers;
    using Orchestra.Modules.TextEditor.Models;
    using Orchestra.Modules.TextEditor.Services.Interfaces;

    public class DocumentService : IDocumentService
    {
        public void GenerateAndApplyNewFileName(Document document, string fileExtension)
        {            
            document.FileName = FileNamesManager.Instance.GetNexDefaulFileName(fileExtension);
            document.CurrentHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(fileExtension);

       /*     var textEditorService = (ITextEditorService)ServiceLocator.Default.ResolveType(typeof(ITextEditorService));
            textEditorService.*/
        }
    }
}
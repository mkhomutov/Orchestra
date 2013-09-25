// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Document.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.Models
{
    using System;
    using System.IO;
    using Catel.Data;
    using ICSharpCode.AvalonEdit.Highlighting;
    using Orchestra.Modules.TextEditor.Models.Interfaces;
    using Orchestra.Modules.TextEditor.ViewModels;
    using Orchestra.Modules.TextEditor.ViewModels.Interfaces;

    internal class Document : ObservableObject, IDocument
    {
        #region Constructors
        public Document()
        {
            Id = Guid.NewGuid();
        }
        #endregion

        #region Properties
        public Guid Id { get; private set; }

        internal ITextEditorViewModel ViewModel { get; set; }
        #endregion

        #region IDocument Members
        public string DocumentName { get; set; }

        public bool Changed { get; set; }        

        public string ConfigurationName { get; set; }

        public IHighlightingDefinition CurrentHighlighting { get; set; }
        #endregion
    }
}
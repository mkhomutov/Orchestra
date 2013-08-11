// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Document.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Orchestra.Modules.TextEditor.Models
{
    using System;
    using Catel.Data;
    using ICSharpCode.AvalonEdit.Highlighting;

    public class Document : ObservableObject
    {
        public Document(string configurationName)
        {
            Id = Guid.NewGuid();
            ConfigurationName = configurationName;
        }

        public Guid Id { get; private set; }

        public string FileName { get; set; }

        public bool Saved { get; set; }

        public bool Changed { get; set; }

        public string ConfigurationName { get; private set; }

        public IHighlightingDefinition CurrentHighlighting { get; set; }
    }
}
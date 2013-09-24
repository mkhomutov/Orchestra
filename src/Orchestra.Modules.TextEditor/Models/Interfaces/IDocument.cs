// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDocument.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.Models.Interfaces
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using ICSharpCode.AvalonEdit.Highlighting;

    public interface IDocument : INotifyPropertyChanged, INotifyPropertyChanging
    {
        #region Properties
        Guid Id { get; }

        string DocumentName { get; }

        bool Changed { get; }

        string ConfigurationName { get; }

        IHighlightingDefinition CurrentHighlighting { get; }
        #endregion
    }
}
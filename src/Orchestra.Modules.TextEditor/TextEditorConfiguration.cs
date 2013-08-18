// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextEditorConfiguration.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using ICSharpCode.AvalonEdit.Highlighting;
    using Orchestra.Modules.TextEditor.Exceptions;
    using Orchestra.Modules.TextEditor.Models;

    public class TextEditorConfiguration
    {

        public TextEditorConfiguration(string configurationName)
        {
            Name = configurationName;
        }
        #region Properties
        /// <summary>
        /// The name of this configuration.
        /// </summary>
        public string Name { get; private set; }

        #endregion
    }
}
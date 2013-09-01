﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HighlightingDefinitionDuplicatedException.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.Exceptions
{
    public class HighlightingDefinitionDuplicatedException : TextEditorException
    {
        #region Constructors
        public HighlightingDefinitionDuplicatedException(string highlightingDefinitionName, string configurationName)
            : base(string.Format("The highlighting definition \"{0}\" was already existed in configuration \"{1}\"", highlightingDefinitionName, configurationName))
        {
        }
        #endregion
    }
}
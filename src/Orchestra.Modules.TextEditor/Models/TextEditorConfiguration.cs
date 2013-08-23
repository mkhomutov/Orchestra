// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextEditorConfiguration.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.Models
{
    using Orchestra.Modules.TextEditor.Models.Interfaces;

    public class TextEditorConfiguration : ITextEditorConfiguration
    {
        #region Properties
        /// <summary>
        /// The name of this configuration.
        /// </summary>
        public string Name { get; set; }
        #endregion
    }
}
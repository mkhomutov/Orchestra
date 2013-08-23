// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITextEditorService.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.Services.Interfaces
{
    using System.Collections.Generic;
    using Orchestra.Modules.TextEditor.Models;
    using Orchestra.Modules.TextEditor.Models.Interfaces;

    /// <summary>
    /// The TextEditor management service.
    /// </summary>
    public interface ITextEditorService
    {
        #region Methods
        TextEditorConfigurationBuilder Configure(string configurationName);

        /// <summary>
        /// </summary>
        /// <returns></returns>
        IDocument CreateDocument(string configurationName);

        /// <summary>
        /// </summary>
        /// <returns></returns>
        IDocument GetActiveDocument();

        void RegisterHighlighting(string schema, params string[] extensions);

        IEnumerable<ITextEditorConfiguration> GetConfigurations();
        #endregion
    }
}
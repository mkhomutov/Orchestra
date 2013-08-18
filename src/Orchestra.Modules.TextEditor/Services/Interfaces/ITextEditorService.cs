// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITextEditorService.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.Services.Interfaces
{
    using Orchestra.Modules.TextEditor.Models;

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
        Document CreateDocument(string configurationName);

        /// <summary>
        /// </summary>
        /// <returns></returns>
        Document GetActiveDocument();

        void RegisterHighlighting(string schema, params string[] extensions);

        #endregion

        void ApplyConfiguration(TextEditorConfiguration confuguration);

        TextEditorConfiguration GetConfigurationByName(string configurationName);
    }
}
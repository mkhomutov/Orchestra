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
        /*        /// <summary>
                /// Adds highlighting defined by Xshd schema.
                /// </summary>
                /// <param name="name">The name of hightlighting definition.</param>
                /// <param name="extensions">Extensions of files which uses this hightlighting definition.</param>
                /// <param name="schema">The schema of highlighting definition.</param>
                void AddHighlightingSchema(string name, string[] extensions, string schema);

                /// <summary>
                /// Applies highlighting definition with specified name for document.
                /// </summary>
                /// <param name="document">The document which current highlighting should be changed.</param>
                /// <param name="name">The name of highlighting definition.</param>
                void SetHighlightingByName(Document document, string name);

                /// <summary>
                /// 
                /// </summary>
                /// <param name="name"></param>
                void SetDefaultFileName(string name);*/

        TextEditorConfigurationBuilder Configure(string configurationName);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Document CreateDocument(string configurationName);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Document GetActiveDocument();
    }
}
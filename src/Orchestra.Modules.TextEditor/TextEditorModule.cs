// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextEditorModule.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor
{
    using System.Collections.Generic;
    using System.Linq;
    using Catel.IoC;
    using Orchestra.Modules.TextEditor.Models;
    using Orchestra.Modules.TextEditor.Models.Interfaces;
    using Orchestra.Modules.TextEditor.Services;
    using Orchestra.Modules.TextEditor.Services.Interfaces;
    using Orchestra.Modules.TextEditor.ViewModels.Interfaces;
    using Orchestra.Services;

    /// <summary>
    /// The module.
    /// </summary>
    public class TextEditorModule : ModuleBase
    {
        #region Constructors
        /// <summary>
        /// Initializes the module.
        /// </summary>
        public TextEditorModule()
            : base("TextEditorModule")
        {
            ServiceLocator.Default.RegisterType(typeof(IConfigurationsStorage), typeof(ConfigurationsStorage));
            ServiceLocator.Default.RegisterType(typeof(IDocumentsStorage), typeof(DocumentsStorage));
            ServiceLocator.Default.RegisterType<ITextEditorService, TextEditorService>();
            ServiceLocator.Default.RegisterType<IDocumentService, DocumentService>();
        }
        #endregion
    }
}
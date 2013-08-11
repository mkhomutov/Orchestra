﻿namespace Orchestra.Modules.TextEditor.ViewModels
{
    using ICSharpCode.AvalonEdit.Highlighting;
    using Orchestra.Modules.TextEditor.Models;
    using Orchestra.Modules.TextEditor.Services;
    using Orchestra.Modules.TextEditor.Services.Interfaces;

    /// <summary>
    /// JuliaLangEditor view model
    /// </summary>
    class TextEditorViewModel : Orchestra.ViewModels.ViewModelBase
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TextEditorViewModel"/> class.
        /// </summary>
        public TextEditorViewModel()
        {
            
        }
        #endregion        

        public Document Document { get; set; }
    }
}

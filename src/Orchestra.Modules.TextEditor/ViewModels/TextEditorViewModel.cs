// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextEditorViewModel.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.ViewModels
{
    using Orchestra.Modules.TextEditor.Models;
    using Orchestra.ViewModels;

    /// <summary>
    /// JuliaLangEditor view model
    /// </summary>
    internal class TextEditorViewModel : ViewModelBase
    {
        #region Properties
        public Document Document { get; set; }
        #endregion
    }
}
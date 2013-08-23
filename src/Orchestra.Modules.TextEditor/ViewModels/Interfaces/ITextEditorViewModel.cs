// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITextEditorViewModel.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.ViewModels.Interfaces
{
    using Orchestra.Modules.TextEditor.Models.Interfaces;

    public interface ITextEditorViewModel
    {
        #region Properties
        IDocument Document { get; }
        #endregion
    }
}
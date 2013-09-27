// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITextEditorViewModel.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.ViewModels.Interfaces
{
    using Catel.MVVM;
    using Orchestra.Modules.TextEditor.Models.Interfaces;

    public interface ITextEditorViewModel : IViewModel
    {
        #region Properties
        IDocument Document { get; }
        #endregion

        string GetText();
        void SetText(string text);
    }
}
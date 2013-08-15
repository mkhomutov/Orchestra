// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextEditorViewModel.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.ViewModels
{
    using System;
    using System.Reactive;
    using Orchestra.Modules.TextEditor.Models;
    using Orchestra.ViewModels;
    using ReactiveUI;
    using System.Linq;
    using System.Reactive.Linq;
    /// <summary>
    /// JuliaLangEditor view model
    /// </summary>
    internal class TextEditorViewModel : ViewModelBase
    {
        public TextEditorViewModel()
        {
        }

        #region Properties
        private Document _document;
        private IDisposable _bindingToTitle;
        public Document Document
        {
            get { return _document; }
            set
            {
                if (_bindingToTitle != null)
                {
                    _bindingToTitle.Dispose();
                    _bindingToTitle = null;
                }

                _document = value;
                _bindingToTitle = _document.ObservableForProperty(x => x.FileName)
                                           .Select(x => x.Value)
                                           .BindTo(this, x => x.Title);
            }
        }
        #endregion
    }
}
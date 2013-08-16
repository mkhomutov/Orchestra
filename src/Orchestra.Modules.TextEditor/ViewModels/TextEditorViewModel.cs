// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextEditorViewModel.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.ViewModels
{
    using System;
    using System.ComponentModel;

    using Catel;

    using Orchestra.Modules.TextEditor.Models;
    using Orchestra.ViewModels;

    using System.Reactive.Linq;
    /// <summary>
    /// JuliaLangEditor view model
    /// </summary>
    internal class TextEditorViewModel : ViewModelBase
    {
        private readonly string _documentFileNamePropertyName;
        public TextEditorViewModel()
        {
            _documentFileNamePropertyName = ExpressionHelper.GetPropertyName(() => Document.FileName);
        }

        #region Properties
        private Document _document;

        public Document Document
        {
            get { return _document; }
            set
            {
                if (_document != null)
                {
                    throw new InvalidOperationException();
                }

                _document = value;

                Observable.FromEvent<PropertyChangedEventHandler,
                    PropertyChangedEventArgs>(
                    h => ((sender, args) => h(args)),
                    h => Document.PropertyChanged += h,
                    h => Document.PropertyChanged -= h)
                    .Where(x => x.PropertyName == _documentFileNamePropertyName).Select(x => Document.FileName).Subscribe(SetTitle);
            }
        }

        private void SetTitle(string fileName)
        {
            Title = fileName;
        }

        #endregion
    }
}
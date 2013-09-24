// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextEditorViewModel.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Reactive.Linq;
    using Catel;
    using ICSharpCode.AvalonEdit.Document;
    using Orchestra.Modules.TextEditor.Models.Interfaces;
    using Orchestra.Modules.TextEditor.ViewModels.Interfaces;
    using Orchestra.ViewModels;

    /// <summary>
    /// JuliaLangEditor view model
    /// </summary>
    internal class TextEditorViewModel : ViewModelBase, ITextEditorViewModel
    {
        #region Fields
        private readonly string _documentFileNamePropertyName;

        private IDocument _document;
        #endregion

        #region Constructors
        public TextEditorViewModel()
        {
            _documentFileNamePropertyName = ExpressionHelper.GetPropertyName(() => Document.DocumentName);
            TextDocument = new TextDocument();
        }
        #endregion

        public TextDocument TextDocument { get; set; }

        #region ITextEditorViewModel Members
        public IDocument Document
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
                          .Where(x => x.PropertyName == _documentFileNamePropertyName)
                          .Select(x => Document.DocumentName)
                          .Subscribe(SetTitle);
            }
        }

        public string GetText()
        {
            return TextDocument.Text;
        }

        public void SetText(string text)
        {
            TextDocument.Text = text;
        }
        #endregion

        #region Methods
        private void SetTitle(string fileName)
        {
            Title = fileName;
        }
        #endregion
    }
}
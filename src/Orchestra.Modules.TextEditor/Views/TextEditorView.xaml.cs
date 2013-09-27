// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextEditorView.xaml.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.Views
{
    using Orchestra.Modules.TextEditor.Views.Interfaces;
    using Orchestra.Views;

    /// <summary>
    /// Interaction logic for JuliaLangEditorView.xaml.
    /// </summary>
    public partial class TextEditorView : DocumentView, ITextEditorView
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TextEditorView" /> class.
        /// </summary>
        public TextEditorView()
        {            
            InitializeComponent();   
        }
        #endregion
    }
}
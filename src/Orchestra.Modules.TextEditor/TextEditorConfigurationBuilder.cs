// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextEditorConfigurationBuilder.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor
{
    using Orchestra.Modules.TextEditor.Helpers;
    using Orchestra.Modules.TextEditor.Models;
    using Orchestra.Modules.TextEditor.Models.Interfaces;
    using Orchestra.Modules.TextEditor.Services.Interfaces;

    public class TextEditorConfigurationBuilder
    {
        #region Fields
        private readonly ITextEditorService _textEditorService;
        private readonly TextEditorConfiguration _configuration;
        #endregion

        #region Constructors
        public TextEditorConfigurationBuilder(ITextEditorService textEditorService, TextEditorConfiguration configuration, string configurationName)
        {
            _textEditorService = textEditorService;
            _configuration = configuration;
            _configuration.Name = configurationName;
        }
        #endregion

        #region Methods
        public void Apply()
        {
            _textEditorService.ApplyConfiguration(_configuration);
        }
        #endregion
    }
}
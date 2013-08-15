// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextEditorConfigurationBuilder.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor
{
    using System.IO;
    using System.Xml;
    using ICSharpCode.AvalonEdit.Highlighting;
    using ICSharpCode.AvalonEdit.Highlighting.Xshd;

    using Orchestra.Modules.TextEditor.Helpers;
    using Orchestra.Modules.TextEditor.Services.Interfaces;

    public class TextEditorConfigurationBuilder
    {
        #region Fields
        private readonly TextEditorConfiguration _configuration;
        private readonly TextEditorModule _module;
        #endregion

        #region Constructors
        public TextEditorConfigurationBuilder(TextEditorModule module, string configurationName)
        {
            _module = module;
            _configuration = new TextEditorConfiguration(configurationName);
        }
        #endregion

        #region Methods

        public TextEditorConfigurationBuilder AddDefaultFileNameDefinition(string name, params string[] extensions)
        {
            FileNamesManager.Instance.RegisterDefaultFileNameDefinition(name, extensions);

            return this;
        }

        public TextEditorConfiguration Build()
        {            
            return _configuration;            
        }
        #endregion
    }
}
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

    using Orchestra.Modules.TextEditor.Services.Interfaces;

    public class TextEditorConfigurationBuilder
    {
        #region Fields
        private readonly TextEditorConfiguration _configuration;
        private readonly TextEditorModule _module;
        #endregion

        #region Constructors
        public TextEditorConfigurationBuilder(TextEditorModule module, string configName)
        {
            _module = module;
            _configuration = new TextEditorConfiguration(configName);
        }
        #endregion

        #region Methods
        public TextEditorConfigurationBuilder AddHighlightingSchema(string name, string schema)
        {
            using (var strRead = new StringReader(schema))
            {
                using (var reader = XmlReader.Create(strRead))
                {
                    var xshd = HighlightingLoader.LoadXshd(reader);
                    var hilightning = HighlightingLoader.Load(xshd, new HighlightingManager());
                    _configuration.AddHighlighting(name, hilightning);
                }
            }

            return this;
        }

        public TextEditorConfigurationBuilder AddDefaultFileNameDefinition(string fileName)
        {
            _configuration.AddDefaultFileName(fileName);
            return this;
        }

        public TextEditorConfiguration Build()
        {            
            return _configuration;            
        }
        #endregion
    }
}
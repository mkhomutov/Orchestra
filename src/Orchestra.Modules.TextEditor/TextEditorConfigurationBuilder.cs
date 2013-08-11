using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orchestra.Modules.TextEditor
{
    using System.IO;
    using System.Xml;
    using ICSharpCode.AvalonEdit.Highlighting;
    using ICSharpCode.AvalonEdit.Highlighting.Xshd;

    public class TextEditorConfigurationBuilder
    {
        private readonly TextEditorModule _module;

        private readonly TextEditorConfiguration _configuration;

        public TextEditorConfigurationBuilder(TextEditorModule module, string configName)
        {
            _module = module;
            _configuration = new TextEditorConfiguration(configName);
        }

        public TextEditorConfigurationBuilder AddHighlightingSchema(string name, string schema)
        {
            using (var strRead = new StringReader(schema))
            using (var reader = XmlReader.Create(strRead))
            {
                var xshd = HighlightingLoader.LoadXshd(reader);
                var hilightning = HighlightingLoader.Load(xshd, new HighlightingManager());
                _configuration.AddHighlighting(name, hilightning);
            }

            return this;
        }

        public void Configure()
        {
            _module.UpdateConfiguration(_configuration);
        }
    }
}

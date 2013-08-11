using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orchestra.Modules.TextEditor
{
    using ICSharpCode.AvalonEdit.Highlighting;
    using Orchestra.Modules.TextEditor.Exceptions;

    public class TextEditorConfiguration
    {
        public string ConfigurationName { get; private set; }

        private readonly IDictionary<string, IHighlightingDefinition> _hilighnings = new Dictionary<string, IHighlightingDefinition>();

        public TextEditorConfiguration(string configurationName)
        {
            ConfigurationName = configurationName;
        }

        public void AddHighlighting(string name, IHighlightingDefinition hilightning)
        {
            if (_hilighnings.ContainsKey(name))
            {
                throw new HighlightingDefinitionDuplicatedException(name, ConfigurationName);
            }
            
            _hilighnings.Add(name, hilightning);
        }

        internal IHighlightingDefinition GetHighlighting(string highlightingName)
        {
            return _hilighnings[highlightingName];
        }
    }
}

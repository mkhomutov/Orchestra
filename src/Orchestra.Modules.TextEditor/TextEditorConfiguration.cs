// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextEditorConfiguration.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor
{
    using System.Collections.Generic;
    using ICSharpCode.AvalonEdit.Highlighting;
    using Orchestra.Modules.TextEditor.Exceptions;

    public class TextEditorConfiguration
    {
        #region Fields
        public readonly IDictionary<string, IHighlightingDefinition> _hilighnings = new Dictionary<string, IHighlightingDefinition>();
        private readonly IDictionary<string, string> _defaultFileNames = new Dictionary<string, string>();
        #endregion

        #region Constructors
        public TextEditorConfiguration(string configurationName)
        {
            Name = configurationName;
        }
        #endregion

        #region Properties
        /// <summary>
        /// The name of this configuration.
        /// </summary>
        public string Name { get; private set; }
        #endregion

        #region Methods
        public void AddDefaultFileName(string fileName)
        {
            var dotIndex = fileName.LastIndexOf(".");

            var name = string.Empty;
            var extension = string.Empty;

            if (dotIndex >= 0)
            {
                name = fileName.Substring(0, dotIndex);
                extension = fileName.Substring(dotIndex, fileName.Length - dotIndex);
            }

            if (_defaultFileNames.ContainsKey(extension))
            {
                throw new DefaultFileNameDefinitionDuplicatedExtension(extension, Name);
            }

            _defaultFileNames.Add(extension, name);
        }

        public void AddHighlighting(string name, IHighlightingDefinition hilightning)
        {
            if (_hilighnings.ContainsKey(name))
            {
                throw new HighlightingDefinitionDuplicatedException(name, Name);
            }

            _hilighnings.Add(name, hilightning);
        }

        internal IHighlightingDefinition GetHighlighting(string highlightingName)
        {
            return _hilighnings[highlightingName];
        }
        #endregion
    }
}
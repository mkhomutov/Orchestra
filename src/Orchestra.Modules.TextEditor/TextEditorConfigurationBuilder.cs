// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextEditorConfigurationBuilder.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor
{
    using Orchestra.Modules.TextEditor.Helpers;
    using Orchestra.Modules.TextEditor.Interfaces;
    using Orchestra.Modules.TextEditor.Models;
    using Orchestra.Modules.TextEditor.Models.Interfaces;

    public class TextEditorConfigurationBuilder
    {
        #region Fields
        private readonly ITextEditorConfiguration _configuration;
        private readonly ITextEditorModule _module;
        #endregion

        #region Constructors
        public TextEditorConfigurationBuilder(ITextEditorModule module, ITextEditorConfiguration configuration, string configurationName)
        {
            _module = module;
            _configuration = configuration;
            _configuration.Name = configurationName;
        }
        #endregion

        #region Methods
        public TextEditorConfigurationBuilder AddDefaultFileNameDefinition(string name, params string[] extensions)
        {
            FileNamesManager.DefaultInstance.RegisterDefaultFileNameDefinition(name, extensions);

            return this;
        }

        public void Apply()
        {
            _module.ApplyConfiguration(_configuration);
        }
        #endregion
    }
}
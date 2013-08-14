// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigurationApplier.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.Helpers
{
    using Orchestra.Modules.TextEditor.Models;

    internal static class ConfigurationApplier
    {
        #region Methods
        public static void ApplyConfiguration(this Document document, TextEditorConfiguration configuration)
        {
            /// TODO: Highlighting must detected by document properties
            document.CurrentHighlighting = configuration.GetHighlighting(configuration.Name);
        }
        #endregion
    }
}
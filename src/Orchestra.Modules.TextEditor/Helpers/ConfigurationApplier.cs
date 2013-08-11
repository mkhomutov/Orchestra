using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orchestra.Modules.TextEditor.Helpers
{
    using Orchestra.Modules.TextEditor.Models;

    internal static class ConfigurationApplier
    {
        public static void ApplyConfiguration(this Document document, TextEditorConfiguration configuration)
        {
            /// TODO: Highlighting must detected by document properties
            document.CurrentHighlighting = configuration.GetHighlighting(configuration.ConfigurationName);
        }
    }
}

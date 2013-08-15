// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigurationApplier.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.Helpers
{
    using System;
    using System.Linq;

    using ICSharpCode.AvalonEdit.Highlighting;

    using Orchestra.Modules.TextEditor.Exceptions;
    using Orchestra.Modules.TextEditor.Models;

    internal static class ConfigurationExtension
    {
        #region Methods
        public static void ApplyToDocument(this TextEditorConfiguration configuration, Document document)
        {
           // document.CurrentHighlighting = configuration.GetHighlighting(document);
        }

        /*public static string GenerateNextNewFileName(this TextEditorConfiguration configuration, string fileExtension)
        {
        }*/

/*        public static void AddHighlighting(this TextEditorConfiguration configuration, IHighlightingDefinition hilightning)
        {            
            if (configuration.HighlightingDefinitions.Any(x => x.Name == hilightning.Name))
            {
                throw new HighlightingDefinitionDuplicatedException(hilightning.Name, configuration.Name);
            }

            configuration.HighlightingDefinitions.Add(hilightning);
        }*/

/*        public static IHighlightingDefinition GetHighlighting(this TextEditorConfiguration configuration, Document document)
        {
            if (string.IsNullOrEmpty(document.FileName))
            {
                // TODO: create special exception type
                throw new NotImplementedException();
            }

            HighlightingManager.Instance.RegisterHighlighting();

            var splittedFileName = SplitFileName(document.FileName);
            var extension = splittedFileName[1];

            //var highlighting = configuration.HighlightingDefinitions.FirstOrDefault(x => x.MainRuleSet.)


            //return _hilighnings[extension];
            throw new NotImplementedException();
        }*/

       
        #endregion
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultFileNameDefinitionDuplicatedExtension.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Orchestra.Modules.TextEditor.Exceptions
{
    public class DefaultFileNameDefinitionDuplicatedExtension : TextEditorConfigurationException
    {
        public DefaultFileNameDefinitionDuplicatedExtension(string fileExtension, string configurationName)
            : base(string.Format("The default filename definition for files \"{0}\" was already existed in configuration \"{1}\"", fileExtension, configurationName))
        {
        }
    }
}
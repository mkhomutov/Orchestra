// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultFileNameDefinitionDuplicatedExtension.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Orchestra.Modules.TextEditor.Exceptions
{
    public class DefaultFileNameDefinitionDuplicatedExtension : TextEditorConfigurationException
    {
        public DefaultFileNameDefinitionDuplicatedExtension(string fileExtension)
            : base(string.Format("The default filename definition for extension \"{0}\" is already exists.", fileExtension))
        {
        }
    }
}
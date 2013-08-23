// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultFileNameDefinitionNotFoundExtension.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.Exceptions
{
    public class DefaultFileNameDefinitionNotFoundExtension : TextEditorConfigurationException
    {
        #region Constructors
        public DefaultFileNameDefinitionNotFoundExtension(string fileExtension, string configurationName)
            : base(string.Format("Not found default filename definition for files \"{0}\" in configuration \"{1}\"", fileExtension, configurationName))
        {
        }
        #endregion
    }
}
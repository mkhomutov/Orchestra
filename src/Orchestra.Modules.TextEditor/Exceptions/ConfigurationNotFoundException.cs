// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigurationNotFoundException.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Orchestra.Modules.TextEditor.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ConfigurationNotFoundException : TextEditorConfigurationException
    {
        public ConfigurationNotFoundException(string configurationName)
            : base(string.Format("The configuration of TextEditor with name {0} was not registered yet.", configurationName))
        {
        }
    }
}
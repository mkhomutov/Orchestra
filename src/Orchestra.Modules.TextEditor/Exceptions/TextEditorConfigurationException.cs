// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextEditorConfigurationException.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Orchestra.Modules.TextEditor.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class TextEditorConfigurationException : TextEditorException
    {
        public TextEditorConfigurationException()
        {
        }

        public TextEditorConfigurationException(string message) : base(message)
        {
        }

        public TextEditorConfigurationException(string message, Exception inner) : base(message, inner)
        {
        }

        protected TextEditorConfigurationException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
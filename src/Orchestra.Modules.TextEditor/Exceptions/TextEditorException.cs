// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextEditorException.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class TextEditorException : Exception
    {
        #region Constructors
        public TextEditorException()
        {
        }

        public TextEditorException(string message) : base(message)
        {
        }

        public TextEditorException(string message, Exception inner) : base(message, inner)
        {
        }

        protected TextEditorException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
        #endregion
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JuliaException.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Orchestra.Modules.Julia.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class JuliaException : Exception
    {
        #region Constructors
        public JuliaException()
        {
        }

        public JuliaException(string message) : base(message)
        {
        }

        public JuliaException(string message, Exception inner) : base(message, inner)
        {
        }

        protected JuliaException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
        #endregion
    }
}
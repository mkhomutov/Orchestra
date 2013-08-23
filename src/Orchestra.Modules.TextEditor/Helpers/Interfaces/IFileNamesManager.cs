﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFileNamesManager.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.Helpers.Interfaces
{
    public interface IFileNamesManager
    {
        #region Methods
        void RegisterDefaultFileNameDefinition(string name, params string[] extensions);
        #endregion
    }
}
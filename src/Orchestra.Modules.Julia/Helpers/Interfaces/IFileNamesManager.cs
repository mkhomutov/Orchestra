// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFileNamesManager.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.Julia.Helpers.Interfaces
{
    public interface IFileNamesManager
    {
        #region Methods
        void RegisterDefaultFileNameDefinition(string name, params string[] extensions);
        string GetNexDefaulFileName(string extension);
        #endregion
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICongigurationsStorage.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.Models.Interfaces
{
    using System.Collections.Generic;

    public interface IConfigurationsStorage
    {
        #region Methods
        void Add(TextEditorConfiguration configuration);
        bool Existed(string configurationName);
        void Replace(TextEditorConfiguration configuration);
        IEnumerable<TextEditorConfiguration> GetAll();
        #endregion
    }
}
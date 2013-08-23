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
        void Add(ITextEditorConfiguration configuration);
        bool Existed(ITextEditorConfiguration configuration);
        void Replace(ITextEditorConfiguration configuration);
        IEnumerable<ITextEditorConfiguration> GetAll();
        #endregion
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CongigurationsStorage.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.Models
{
    using System;
    using System.Collections.Generic;
    using Orchestra.Modules.TextEditor.Models.Interfaces;

    public class CongigurationsStorage : IConfigurationsStorage
    {
        #region IConfigurationsStorage Members
        public void Add(ITextEditorConfiguration configuration)
        {
            throw new NotImplementedException();
        }

        public bool Existed(ITextEditorConfiguration configuration)
        {
            throw new NotImplementedException();
        }

        public void Replace(ITextEditorConfiguration configuration)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITextEditorConfiguration> GetAll()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
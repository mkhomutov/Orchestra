// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CongigurationsStorage.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.TextEditor.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Orchestra.Modules.TextEditor.Models.Interfaces;

    public class ConfigurationsStorage : IConfigurationsStorage
    {
        private IList<ITextEditorConfiguration> _configList = new List<ITextEditorConfiguration>();
        #region IConfigurationsStorage Members
        public void Add(ITextEditorConfiguration configuration)
        {
            _configList.Add(configuration);
        }

        public bool Existed(ITextEditorConfiguration configuration)
        {
            return _configList.Any(x => x.Name == configuration.Name);
        }

        public void Replace(ITextEditorConfiguration configuration)
        {
            var toRemove = _configList.FirstOrDefault(x => x.Name == configuration.Name);
            if (toRemove != null)
            {
                _configList.Remove(toRemove);
                _configList.Add(configuration);
            }
        }

        public IEnumerable<ITextEditorConfiguration> GetAll()
        {
            return _configList.AsEnumerable();
        }
        #endregion
    }
}
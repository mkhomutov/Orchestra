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
        private IList<TextEditorConfiguration> _configList = new List<TextEditorConfiguration>();
        #region IConfigurationsStorage Members
        public void Add(TextEditorConfiguration configuration)
        {
            _configList.Add(configuration);
        }

        public bool Existed(string configurationName)
        {
            return _configList.Any(x => x.Name == configurationName);
        }

        public void Replace(TextEditorConfiguration configuration)
        {
            var toRemove = _configList.FirstOrDefault(x => x.Name == configuration.Name);
            if (!toRemove.Equals(default(TextEditorConfiguration)))
            {
                _configList.Remove(toRemove);
                _configList.Add(configuration);
            }
        }

        public IEnumerable<TextEditorConfiguration> GetAll()
        {
            return _configList.AsEnumerable();
        }
        #endregion
    }
}
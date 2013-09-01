namespace Orchestra.Modules.TextEditor.Services
{
    using System.Collections.Generic;
    using Orchestra.Modules.TextEditor.Exceptions;
    using Orchestra.Modules.TextEditor.Services.Interfaces;

    internal class FileNamesManager : IFileNamesManager
    {

        #region Fields
        private readonly IDictionary<string, int> _counters = new Dictionary<string, int>();
        private readonly IDictionary<string, string> _defaultFileNames = new Dictionary<string, string>();
        #endregion

        #region Constructors
        public FileNamesManager()
        {
        }
        #endregion

        #region Methods
        public void RegisterDefaultFileNameDefinition(string name, params string[] extensions)
        {
            foreach (string extension in extensions)
            {
                if (_defaultFileNames.ContainsKey(extension))
                {
                    throw new DefaultFileNameDefinitionDuplicatedExtension(extension);
                }

                _defaultFileNames.Add(extension, name);
            }
        }

        public string GetNexDefaulFileName(string extension)
        {
            if (!_counters.ContainsKey(extension))
            {
                _counters.Add(extension, 1);
            }

            return string.Format("{0}{1}{2}", _defaultFileNames[extension], _counters[extension]++, extension);
        }
        #endregion
    }
}
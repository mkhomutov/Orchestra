using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orchestra.Modules.TextEditor.Helpers
{
    using Orchestra.Modules.TextEditor.Exceptions;

    internal class FileNamesManager
    {
        private static readonly FileNamesManager _instance = new FileNamesManager();
        private readonly IDictionary<string, string> _defaultFileNames = new Dictionary<string, string>();
        private readonly IDictionary<string, int> _counters = new Dictionary<string, int>();

        private FileNamesManager()
        {
        }

        public static FileNamesManager Instance 
        {
            get
            {
                return _instance;
            }
        }

        public void RegisterDefaultFileNameDefinition(string name, params string[] extensions)
        {
            foreach (var extension in extensions)
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


    }
}

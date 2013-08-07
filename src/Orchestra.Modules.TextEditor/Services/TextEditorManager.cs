using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orchestra.Modules.TextEditor.Services
{
    using System.IO;
    using System.Xml;
    using Catel.MVVM;
    using ICSharpCode.AvalonEdit.Highlighting;
    using ICSharpCode.AvalonEdit.Highlighting.Xshd;
    using Orchestra.Models;
    using Orchestra.Modules.TextEditor.Services.Interfaces;
    using Orchestra.Modules.TextEditor.ViewModels;
    using Orchestra.Services;

    internal class TextEditorManager : ServiceBase, ITextEditorManager
    {
        private IList<IHighlightingDefinition> hilighnings = new List<IHighlightingDefinition>();

        public void AddHighlightingSchema(string name, string[] extensions, string schema)
        {
            using(var strRead = new StringReader(schema))
            using (var reader = XmlReader.Create(strRead))
            {
                var xshd = HighlightingLoader.LoadXshd(reader);
                var hilightning = HighlightingLoader.Load(xshd, new HighlightingManager());
                hilighnings.Add(hilightning);
            }
        }

        public void ShowEditor()
        {
            var orchestraService = GetService<IOrchestraService>();
            orchestraService.ShowDocument<TextEditorViewModel>();
        }
    }
}

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
        private IDictionary<string, IHighlightingDefinition> hilighnings = new Dictionary<string, IHighlightingDefinition>();
        private IDictionary<Guid, TextEditorViewModel> editors = new Dictionary<Guid, TextEditorViewModel>();

        public void AddHighlightingSchema(string name, string[] extensions, string schema)
        {
            using(var strRead = new StringReader(schema))
            using (var reader = XmlReader.Create(strRead))
            {
                var xshd = HighlightingLoader.LoadXshd(reader);
                var hilightning = HighlightingLoader.Load(xshd, new HighlightingManager());
                hilighnings.Add(name, hilightning);
            }
        }

        public void SetHighlightingByName(Guid editorId, string name)
        {
            editors[editorId].CurrentHighlighting = hilighnings[name];
        }

        public Guid ShowEditor()
        {            
            var orchestraService = GetService<IOrchestraService>();
            var textEditor = new TextEditorViewModel();
            var id = Guid.NewGuid();
            editors.Add(id, textEditor);
            orchestraService.ShowDocument(textEditor);

            return id;
        }
    }
}

namespace Orchestra.Modules.TextEditor.Services.Interfaces
{
    using System;

    public interface ITextEditorManager
    {
        void AddHighlightingSchema(string name, string[] extensions, string schema);

        void SetHighlightingByName(Guid editorId, string name);

        Guid ShowEditor();
    }
}

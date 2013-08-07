namespace Orchestra.Modules.TextEditor.Services.Interfaces
{
    public interface ITextEditorManager
    {
        void AddHighlightingSchema(string name, string[] extensions, string schema);
        void ShowEditor();
    }
}

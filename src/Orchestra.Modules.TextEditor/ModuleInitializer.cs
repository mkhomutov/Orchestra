using System.Collections.Generic;
using Catel.IoC;
using Orchestra.Modules.TextEditor;
using Orchestra.Modules.TextEditor.Interfaces;
using Orchestra.Modules.TextEditor.Models.Interfaces;
using Orchestra.Modules.TextEditor.Services;
using Orchestra.Modules.TextEditor.Services.Interfaces;
using Orchestra.Modules.TextEditor.ViewModels.Interfaces;

/// <summary>
/// Used by the ModuleInit. All code inside the Initialize method is ran as soon as the assembly is loaded.
/// </summary>
public static class ModuleInitializer
{
    #region Methods
    /// <summary>
    /// Initializes the module.
    /// </summary>
    public static void Initialize()
    {
        ServiceLocator.Default.RegisterType(typeof (IList<int>), typeof (List<int>));

        ServiceLocator.Default.RegisterType(typeof (IDictionary<IDocument, ITextEditorViewModel>), typeof (Dictionary<IDocument, ITextEditorViewModel>));
        //    ServiceLocator.Default.RegisterType(typeof(IDictionary<string, TextEditorConfiguration>), typeof(Dictionary<string, TextEditorConfiguration>));

        //   ServiceLocator.Default.RegisterType(typeof(IDictionary<,>), typeof(Dictionary<,>));
        ServiceLocator.Default.RegisterType<ITextEditorModule, TextEditorModule>();
        ServiceLocator.Default.RegisterType<ITextEditorService, TextEditorService>();
        ServiceLocator.Default.RegisterType<IDocumentService, DocumentService>();
    }
    #endregion
}
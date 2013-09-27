namespace Orchestra.Modules.TextEditor.TestShell.Menu
{
    using Catel.IoC;
    using Catel.MVVM;

    using Orchestra.Models;
    using Orchestra.Modules.TextEditor.Services.Interfaces;
    using Orchestra.Services;

    /// <summary>
    /// The module.
    /// </summary>
    public class MyModule : ModuleBase
    {
        /// <summary>
        /// Initializes the module.
        /// </summary>
        public MyModule()
            : base("MyModule")
        {
        }

        /// <summary>
        /// Called when the module is initialized.
        /// </summary>
        protected override void OnInitialized()
        {
            ConfigureTextEditor();
        }

        protected override void InitializeRibbon(IRibbonService ribbonService)
        {
            ribbonService.RegisterRibbonItem(new RibbonButton(HomeRibbonTabName, ModuleName, "TextEditor", new Command(OnShowTextEditor)));

            base.InitializeRibbon(ribbonService);
        }

        private static void OnShowTextEditor()
        {
            var textEditorService = (ITextEditorService)ServiceLocator.Default.ResolveType(typeof(ITextEditorService));
            var documentService = (IDocumentService)ServiceLocator.Default.ResolveType(typeof(IDocumentService));

            var document = textEditorService.CreateDocument("TestConfiguration");            
            documentService.SetHighlighting(document, "*.txt");
        }

        private static void ConfigureTextEditor()
        {
            var textEditorService = DependencyResolverManager.Default.DefaultDependencyResolver.Resolve<ITextEditorService>();

            textEditorService.Configure("TestConfiguration")
                             .Apply();
        }
    }
}
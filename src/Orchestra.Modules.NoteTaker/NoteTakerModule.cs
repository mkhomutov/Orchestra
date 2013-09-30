namespace Orchestra.Modules.NoteTaker
{
    using Catel.IoC;
    using Catel.MVVM;
    using Catel.Messaging;

    using Orchestra.Messages;
    using Orchestra.Models;
    using Orchestra.Modules.TextEditor.Models.Interfaces;
    using Orchestra.Modules.TextEditor.Services.Interfaces;
    using Orchestra.Services;

    /// <summary>
    /// The module.
    /// </summary>
    public class NoteTakerModule : ModuleBase
    {
        #region Constructors
        /// <summary>
        /// Initializes the module.
        /// </summary>
        public NoteTakerModule()
            : base("NoteTakerModule")
        {
            MessageMediator.Default.Register<ModuleInitializedMessage>(this, this.OnModuleInitialized);
        }
        #endregion

        #region Methods
        private void OnModuleInitialized(ModuleInitializedMessage msg)
        {
            if (msg.ModuleName != "TextEditorModule")
            {
                return;
            }

            ConfigureTextEditor();
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
            ribbonService.RegisterRibbonItem(new RibbonButton(HomeRibbonTabName, this.ModuleName, "TextEditor", new Command(OnShowTextEditor)));

            base.InitializeRibbon(ribbonService);
        }

        private static void OnShowTextEditor()
        {
            if (!IsServiceRegistered<ITextEditorService>())
            {
                return;
            }

            var textEditorService = (ITextEditorService)ServiceLocator.Default.ResolveType(typeof(ITextEditorService));
            var documentService = (IDocumentService)ServiceLocator.Default.ResolveType(typeof(IDocumentService));

            IDocument document = textEditorService.CreateDocument("TestConfiguration");
            documentService.SetHighlighting(document, "*.txt");
        }

        private static void ConfigureTextEditor()
        {
            if (!IsServiceRegistered<ITextEditorService>())
            {
                return;
            }

            var textEditorService = DependencyResolverManager.Default.DefaultDependencyResolver.Resolve<ITextEditorService>();

            textEditorService.Configure("TestConfiguration").Apply();
        }

        private static bool IsServiceRegistered<T>()
        {
            return DependencyResolverManager.Default.DefaultDependencyResolver.CanResolve<T>();
        }
        #endregion
    }
}
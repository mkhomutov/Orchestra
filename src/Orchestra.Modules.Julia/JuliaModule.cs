namespace Orchestra.Modules.Julia
{
    using Catel.MVVM;
    using Catel.MVVM.Services;
    using Orchestra.Messages;
    using Orchestra.Models;
    using Orchestra.Modules;
    using Orchestra.Modules.Julia.ViewModels;
    using Orchestra.Modules.Julia.Views.Interfaces;
    using Orchestra.Modules.TextEditor.Services;
    using Orchestra.Modules.TextEditor.Services.Interfaces;
    using Orchestra.Modules.TextEditor.Views;
    using Orchestra.Modules.TextEditor.Views.Interfaces;
    using Orchestra.Services;
    using Orchestra.Views;

    /// <summary>
    /// The module.
    /// </summary>
    public class JuliaModule : Orchestra.Modules.ModuleBase
    {
        private const string ConfigurationName = "Julia";

        /// <summary>
        /// Initializes the module.
        /// </summary>
        public JuliaModule()
            : base("JuliaModule")
        {
            Catel.Messaging.MessageMediator.Default.Register<ModuleInitialized>(this, OnModuleLoaded);
        }

        /// <summary>
        /// Called when the module is initialized.
        /// </summary>
        protected override void OnInitialized()
        {
            var orchestraService = GetService<IOrchestraService>();

            // TODO: Register ribbon items
            //var openRibbonItem = new RibbonItem(ModuleName, ModuleName, "Action name", new Command(() =>
            //    {
            //        // Action to invoke
            //    }));
            //orchestraService.AddRibbonItem(openRibbonItem);

            // TODO: Handle additional initialization code
        }

        /// <summary>
        /// Initializes the ribbon.
        /// <para />
        /// Use this method to hook up views to ribbon items.
        /// </summary>
        /// <param name="ribbonService">The ribbon service.</param>
        protected override void InitializeRibbon(IRibbonService ribbonService)
        {
            const string juliaTabName = "Julia";
            ribbonService.RegisterRibbonItem(new RibbonButton(HomeRibbonTabName, ModuleName, "Julia", new Command(OnShowJuliaStartPage)));

            ribbonService.RegisterContextualRibbonItem<IJuliaStartPageView>(new RibbonButton(juliaTabName, "File", "New", new Command(OnNew, CanCreateNew)) { ItemImage = "/Orchestra.Library;component/Resources/Images/FileOpen.png" }, juliaTabName);

            ribbonService.RegisterContextualRibbonItem<IJuliaStartPageView>(new RibbonButton(juliaTabName, "File", "Open", new Command(OnOpen, CanOpen)) { ItemImage = "/Orchestra.Library;component/Resources/Images/FileOpen.png" }, juliaTabName);

            ribbonService.RegisterContextualRibbonItem<ITextEditorView>(new RibbonButton(juliaTabName, "File", "Save", new Command(OnSave, CanSave)) { ItemImage = "/Orchestra.Library;component/Resources/Images/FileSave.png" },
                juliaTabName);

            ribbonService.RegisterContextualRibbonItem<ITextEditorView>(new RibbonButton(juliaTabName, "File", "Save as ...", new Command(OnSaveAs, CanSaveAs)) { ItemImage = "/Orchestra.Library;component/Resources/Images/FileSave.png" },
                juliaTabName);
        }

        private void OnModuleLoaded(ModuleInitialized msg)
        {
            if (msg.ModuleName != "TextEditorModule")
            {
                return;
            }

            ConfigureTextEditor();
        }

        private void ConfigureTextEditor()
        {
            var textEditorService = (ITextEditorService)Catel.IoC.ServiceLocator.Default.ResolveType(typeof(ITextEditorService));

            textEditorService.Configure(ConfigurationName)
                             .AddHighlightingSchema(ConfigurationName, Properties.Resources.JuliaLang)
                             .Configure();
        }

        private void OnNew()
        {
            var textEditorService = (ITextEditorService) Catel.IoC.ServiceLocator.Default.ResolveType(typeof (ITextEditorService));
            textEditorService.CreateDocument(ConfigurationName);
        }

        private bool CanCreateNew()
        {
            return true;
        }

        private void OnOpen()
        {
            throw new System.NotImplementedException();
        }

        private bool CanOpen()
        {
            return true;
        }

        private void OnSave()
        {
            throw new System.NotImplementedException();
        }

        private bool CanSave()
        {
            if (!Catel.IoC.ServiceLocator.Default.AreAllTypesRegistered(typeof (ITextEditorService)))
            {
                return false;
            }

            var textEditorService = (ITextEditorService)Catel.IoC.ServiceLocator.Default.ResolveType(typeof(ITextEditorService));
            var activeDocument = textEditorService.GetActiveDocument();
            return activeDocument != null;
        }

        private void OnSaveAs()
        {
            throw new System.NotImplementedException();
        }

        private bool CanSaveAs()
        {
            return false;
        }

        private void OnShowJuliaStartPage()
        {
            var orchestraService = GetService<IOrchestraService>();

            orchestraService.ShowDocument<JuliaStartPageViewModel>();
        }
    }
}
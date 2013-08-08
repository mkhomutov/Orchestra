namespace Orchestra.Modules.Julia
{
    using Catel.MVVM;
    using Catel.MVVM.Services;
    using Orchestra.Models;
    using Orchestra.Modules;
    using Orchestra.Modules.TextEditor.Services;
    using Orchestra.Modules.TextEditor.Services.Interfaces;
    using Orchestra.Services;

    /// <summary>
    /// The module.
    /// </summary>
    public class JuliaModule : Orchestra.Modules.ModuleBase
    {
        /// <summary>
        /// Initializes the module.
        /// </summary>
        public JuliaModule()
            : base("JuliaModule")
        {
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
            ribbonService.RegisterRibbonItem(new RibbonButton(HomeRibbonTabName, ModuleName, "Julia", new Command(OnShowJuliaEditor)));
        }

        private static void OnShowJuliaEditor()
        {
            var textEditor = (ITextEditorManager)Catel.IoC.ServiceLocator.Default.GetService(typeof(ITextEditorManager));
            textEditor.AddHighlightingSchema("Julia", new [] { "*.jl" }, Properties.Resources.JuliaLang);
            var id = textEditor.ShowEditor();
            textEditor.SetHighlightingByName(id, "Julia");
        }
    }
}
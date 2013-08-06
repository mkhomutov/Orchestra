namespace Orchestra.Modules.JuliaEditor
{
    using Catel.MVVM;
    using Catel.MVVM.Services;
    using Orchestra.Models;
    using Orchestra.Modules;
    using Orchestra.Services;

    /// <summary>
    /// The module.
    /// </summary>
    public class MyModule : Orchestra.Modules.ModuleBase
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
            var orchestraService = GetService<IOrchestraService>();

            // TODO: Register ribbon items
            //var openRibbonItem = new RibbonItem(ModuleName, ModuleName, "Action name", new Command(() =>
            //    {
            //        // Action to invoke
            //    }));
            //orchestraService.AddRibbonItem(openRibbonItem);

            // TODO: Handle additional initialization code
        }
    }
}
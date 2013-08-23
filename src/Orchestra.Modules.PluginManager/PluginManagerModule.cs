namespace Orchestra.Modules.PluginsManager
{
    using System;
    using Catel.MVVM;
    using Catel.MVVM.Services;
    using Microsoft.Build.BuildEngine;
    using Orchestra.Models;
    using Orchestra.Modules;
    using Orchestra.Services;

    /// <summary>
    /// The module.
    /// </summary>
    public class PluginManagerModule : Orchestra.Modules.ModuleBase
    {
        /// <summary>
        /// Initializes the module.
        /// </summary>
        public PluginManagerModule(IRibbonService ribbonService)
            : base("PluginManagerModule", ribbonService)
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

        protected override void InitializeRibbon(IRibbonService ribbonService)
        {
            var orchestraService = GetService<IOrchestraService>();

            ribbonService.RegisterRibbonItem(new RibbonButton(HomeRibbonTabName, ModuleName, "PluginManager", new Command(Func)));
            base.InitializeRibbon(ribbonService);
        }

        private void Func()
        {
            
        }

    }
}
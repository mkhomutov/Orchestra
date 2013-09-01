// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JuliaModule.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Modules.Julia
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Catel.IoC;
    using Catel.MVVM;
    using Catel.Messaging;
    using Orchestra.Messages;
    using Orchestra.Models;
    using Orchestra.Modules.Julia.Properties;
    using Orchestra.Modules.Julia.ViewModels;
    using Orchestra.Modules.Julia.Views.Interfaces;
    using Orchestra.Modules.TextEditor.Models;
    using Orchestra.Modules.TextEditor.Services.Interfaces;
    using Orchestra.Modules.TextEditor.ViewModels.Interfaces;
    using Orchestra.Modules.TextEditor.Views.Interfaces;
    using Orchestra.Services;

    /// <summary>
    /// The module.
    /// </summary>
    public class JuliaModule : ModuleBase
    {
        #region Constants
        private const string ConfigurationName = "Julia";
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes the module.
        /// </summary>
        public JuliaModule(IRibbonService ribbonService)
            : base("JuliaModule", ribbonService)
        {
            MessageMediator.Default.Register<ModuleInitialized>(this, OnModuleInitialized);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Called when the module is initialized.
        /// </summary>
        protected override void OnInitialized()
        {
        }

        /// <summary>
        /// Initializes the ribbon.
        ///     <para />
        /// Use this method to hook up views to ribbon items.
        /// </summary>
        /// <param name="ribbonService">The ribbon service.</param>
        protected override void InitializeRibbon(IRibbonService ribbonService)
        {
            const string juliaTabName = "Julia";
            ribbonService.RegisterRibbonItem(new RibbonButton(HomeRibbonTabName, ModuleName, "Julia", new Command(OnShowJuliaStartPage)));

            ribbonService.RegisterContextualRibbonItem<IJuliaStartPageView>(new RibbonButton(juliaTabName, "File", "New", new Command(OnNew, CanCreateNew)) {ItemImage = "/Orchestra.Library;component/Resources/Images/FileOpen.png"}, juliaTabName);

            ribbonService.RegisterContextualRibbonItem<IJuliaStartPageView>(new RibbonButton(juliaTabName, "File", "Open", new Command(OnOpen, CanOpen)) {ItemImage = "/Orchestra.Library;component/Resources/Images/FileOpen.png"}, juliaTabName);

            ribbonService.RegisterContextualRibbonItem<ITextEditorView>(new RibbonButton(juliaTabName, "File", "Save", new Command(OnSave, CanSave)) {ItemImage = "/Orchestra.Library;component/Resources/Images/FileSave.png"},
                                                                        juliaTabName);

            ribbonService.RegisterContextualRibbonItem<ITextEditorView>(new RibbonButton(juliaTabName, "File", "Save as ...", new Command(OnSaveAs, CanSaveAs)) {ItemImage = "/Orchestra.Library;component/Resources/Images/FileSave.png"},
                                                                        juliaTabName);
        }

        private void OnModuleInitialized(ModuleInitialized msg)
        {
            // TODO: somehow extract TextEditorModule.Name. May be create static method GetModuleName
            if (msg.ModuleName != "TextEditorModule")
            {
                return;
            }

            ConfigureTextEditor();
        }

        private static void ConfigureTextEditor()
        {
            var textEditorService = DependencyResolverManager.Default.DefaultDependencyResolver.Resolve<ITextEditorService>();

            textEditorService.RegisterHighlighting(Resources.JuliaLang, ".jl");
            textEditorService.FileNamesManager.RegisterDefaultFileNameDefinition("NewFile", ".jl");

            textEditorService.Configure(ConfigurationName)
                             .Apply();
        }

        private static void OnNew()
        {
            var textEditorService = (ITextEditorService) ServiceLocator.Default.ResolveType(typeof (ITextEditorService));
            var documentService = (IDocumentService)ServiceLocator.Default.ResolveType(typeof(IDocumentService));

            var document = textEditorService.CreateDocument(ConfigurationName);
            var newFileName = textEditorService.FileNamesManager.GetNexDefaulFileName(".jl");
            File.Create(newFileName).Dispose();
            var file = new FileInfo(newFileName);
            documentService.AttachFileToDocument(document, file);
        }

        private static bool CanCreateNew()
        {
            return true;
        }

        private void OnOpen()
        {
            throw new NotImplementedException();
        }

        private bool CanOpen()
        {
            return true;
        }

        private void OnSave()
        {
            throw new NotImplementedException();
        }

        private static bool CanSave()
        {
            if (!IsServiceRegistered<ITextEditorService>())
            {
                return false;
            }

            var textEditorService = DependencyResolverManager.Default.DefaultDependencyResolver.Resolve<ITextEditorService>();
            var activeDocument = textEditorService.GetActiveDocument();
            return activeDocument != null && activeDocument.Changed;
        }

        private void OnSaveAs()
        {
            throw new NotImplementedException();
        }

        private static bool CanSaveAs()
        {
            if (!IsServiceRegistered<ITextEditorService>())
            {
                return false;
            }

            var textEditorService = (ITextEditorService)ServiceLocator.Default.ResolveType(typeof(ITextEditorService));
            var activeDocument = textEditorService.GetActiveDocument();
            return activeDocument != null && !activeDocument.Changed;
        }

        private static bool IsServiceRegistered<T>()
        {
            return DependencyResolverManager.Default.DefaultDependencyResolver.CanResolve<T>();
      //      return ServiceLocator.Default.AreAllTypesRegistered(typeof (T));
        }

        private void OnShowJuliaStartPage()
        {
            var orchestraService = GetService<IOrchestraService>();

            orchestraService.ShowDocument<JuliaStartPageViewModel>();
        }
        #endregion
    }
}
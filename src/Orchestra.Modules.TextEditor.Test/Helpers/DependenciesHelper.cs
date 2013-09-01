// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DependenciesHelper.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Orchestra.Modules.TextEditor.Test.Helpers
{
    using System.Collections.Generic;
    using Catel.IoC;
    using NSubstitute;
    using Orchestra.Modules.TextEditor.Models;
    using Orchestra.Modules.TextEditor.Models.Interfaces;
    using Orchestra.Modules.TextEditor.Services;
    using Orchestra.Modules.TextEditor.Services.Interfaces;
    using Orchestra.Modules.TextEditor.ViewModels.Interfaces;
    using Orchestra.Services;

    public class DependenciesHelper
    {
        private readonly ServiceLocator _serviceLocator;
        private readonly TypeFactory _typeFactory;
        private readonly IDependencyResolver _dependencyResolver;

        public DependenciesHelper()
        {
            _serviceLocator = new ServiceLocator();
            _dependencyResolver = new CatelDependencyResolver(_serviceLocator);
            _typeFactory = new TypeFactory(_dependencyResolver);
            _serviceLocator.RegisterInstance(_typeFactory);
        }

        public DependenciesHelper RegisterInstance<T>(T instance)
        {
            _serviceLocator.RegisterInstance(instance);
            return this;
        }

        public void RegistrerSubstituteFor<T>() where T : class 
        {
            RegisterInstance(Substitute.For<T>());
        }

        public ITextEditorService CreateTextEditorServiceInstance()
        {
            RegistrerSubstituteFor<IOrchestraService>();
            RegistrerSubstituteFor<IFileNamesManager>();
            RegistrerSubstituteFor<IDocumentsStorage>();
            RegistrerSubstituteFor<IConfigurationsStorage>();

            return CreateInstance<TextEditorService>();
        }

        public IDocumentService CreateDocumentServiceInstance()
        {
            return CreateInstance<DocumentService>();
        }

        public T CreateInstance<T>()
        {
            return _typeFactory.CreateInstance<T>();
        }

        public T Resolve<T>()
        {
            return _dependencyResolver.Resolve<T>();
        }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextEditorModuleTest.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orchestra.Modules.TextEditor.Test
{
    using System;
    using System.Collections.Generic;
    using Catel.IoC;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NSubstitute;
    using Orchestra.Modules.TextEditor.Interfaces;
    using Orchestra.Modules.TextEditor.Models;
    using Orchestra.Modules.TextEditor.Test.Helpers;
    using Orchestra.Modules.TextEditor.ViewModels.Interfaces;
    using Orchestra.Services;

    [TestClass]
    public class TextEditorModuleTest
    {
        [TestMethod]
        public void CanAddDocument()
        {
            var dependencyHelper = new DependenciesHelper();
            var module = dependencyHelper.CreateTextEditorModuleInstance();
            var documents = dependencyHelper.Resolve<IDictionary<Document, ITextEditorViewModel>>();

            var viewModel = Substitute.For<ITextEditorViewModel>();
            var doc = new Document();
            viewModel.Document.Returns(doc);

            module.AddDocument(viewModel);

            documents.Received()
                     .Add(doc, viewModel);
        }

        [TestMethod]
        public void CanGetDocument()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void CanAddConfiguration()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void CanGetConfiguration()
        {
            throw new NotImplementedException();
        }
    }
}

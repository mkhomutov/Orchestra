// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextEditorServiceTest.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Orchestra.Modules.TextEditor.Test
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Orchestra.Modules.TextEditor.Models;
    using Orchestra.Modules.TextEditor.Models.Interfaces;
    using Orchestra.Modules.TextEditor.Test.Helpers;
    using NSubstitute;
    using Orchestra.Modules.TextEditor.ViewModels.Interfaces;
    using Orchestra.Services;

    [TestClass]
    public class TextEditorServiceTest
    {
        [TestMethod]
        public void CanConfigure()
        {
            // Arrange
            var dependncyHelper = new DependenciesHelper();
            var textEditorService = dependncyHelper.CreateTextEditorServiceInstance();
            // Act
            var configBuilder = textEditorService.Configure("configName");
            // Assert
            Assert.IsNotNull(configBuilder);
        }

        [TestMethod]
        public void CanCreateDocumentWithExistedConfuguration()
        {
            // Arrange
            const string configName = "configName";

            var dependncyHelper = new DependenciesHelper();
            var textEditorService = dependncyHelper.CreateTextEditorServiceInstance();

            var configStorage = dependncyHelper.Resolve<IConfigurationsStorage>();
            var docStorage = dependncyHelper.Resolve<IDocumentsStorage>();
            var orchestra = dependncyHelper.Resolve<IOrchestraService>();

            var configuration = Substitute.For<TextEditorConfiguration>();
            configuration.Name.Returns(configName);

            configStorage.GetAll()
                         .Returns(x => new[] { configuration });

            var exceptionCatched = false;
            IDocument doc = null;
            
            // Act
            try
            {
                doc = textEditorService.CreateDocument(configName);
            }
            catch (Exception)
            {
                exceptionCatched = true;
            }
            
            // Assert
            Assert.IsFalse(exceptionCatched);
            Assert.IsNotNull(doc);
            docStorage.ReceivedWithAnyArgs().Add(Substitute.For<ITextEditorViewModel>());
            orchestra.ReceivedWithAnyArgs().ShowDocument((ITextEditorViewModel)null);
        }

        [TestMethod]
        public void CreateDocumentWithMissingConfugurationTest()
        {
            // Arrange
            var dependncyHelper = new DependenciesHelper();
            var textEditorService = dependncyHelper.CreateTextEditorServiceInstance();

            var configStorage = dependncyHelper.Resolve<IConfigurationsStorage>();
            var docStorage = dependncyHelper.Resolve<IDocumentsStorage>();
            const string configName = "configName";

            configStorage.GetAll()
                         .Returns(x => new TextEditorConfiguration[] { });
            var orchestra = dependncyHelper.Resolve<IOrchestraService>();

            var exceptionCatched = false;
            IDocument doc = null;

            // Act
            try
            {
                doc = textEditorService.CreateDocument(configName);
            }
            catch (Exception)
            {
                exceptionCatched = true;
            }

            // Assert
            Assert.IsTrue(exceptionCatched);
            Assert.IsNull(doc);
            docStorage.DidNotReceiveWithAnyArgs().Add(null);
            orchestra.DidNotReceiveWithAnyArgs().ShowDocument((ITextEditorViewModel)null);
        }

        [TestMethod]
        public void CanGetActiveDocument()
        {
            // Arrange
            var dependncyHelper = new DependenciesHelper();
            var textEditorService = dependncyHelper.CreateTextEditorServiceInstance();

            var doc = Substitute.For<IDocument>();            
            var id = Guid.NewGuid();
            doc.Id.Returns(x => id);
            var vm = Substitute.For<ITextEditorViewModel>();
            vm.Document.Returns(doc);

            var activeDoc = Substitute.For<IDocument>();
            var activeId = Guid.NewGuid();
            activeDoc.Id.Returns(x => activeId);
            var activeVm = Substitute.For<ITextEditorViewModel>();
            activeVm.Document.Returns(activeDoc);

            var docStorage = dependncyHelper.Resolve<IDocumentsStorage>();
            var orchestra = dependncyHelper.Resolve<IOrchestraService>();

            docStorage.GetAll()
                  .Returns(x => new[] { vm, activeVm });
            orchestra.IsActive<ITextEditorViewModel>(doc)
                     .ReturnsForAnyArgs(x => ((ITextEditorViewModel)x[0]).Document.Id.Equals(activeDoc.Id));

            // Act
            var detectedDoc = textEditorService.GetActiveDocument();

            // Assert
            Assert.IsNotNull(detectedDoc);
            Assert.AreEqual(activeDoc.Id, detectedDoc.Id);
            docStorage.Received().GetAll();
            orchestra.ReceivedWithAnyArgs()
                     .IsActive<ITextEditorViewModel>(null);
        }

        [TestMethod]
        public void CanRegisterHighlighting()
        {
            // Arrange
            var dependncyHelper = new DependenciesHelper();
            var textEditorService = dependncyHelper.CreateTextEditorServiceInstance();
            var catchedException = false;

            // Act
            try
            {
                textEditorService.RegisterHighlighting(Properties.Resources.Test, new [] {".ext"});
            }
            catch (Exception)
            {
                catchedException = true;
            }

            // Assert
            Assert.IsFalse(catchedException);
        }

        [TestMethod]
        public void CanGetConfigurations()
        {
            // Arrange
            var dependncyHelper = new DependenciesHelper();
            var textEditorService = dependncyHelper.CreateTextEditorServiceInstance();

            var configStorage = dependncyHelper.Resolve<IConfigurationsStorage>();

            // Act
            var configurations = textEditorService.GetConfigurations();

            // Assert
            Assert.IsNotNull(configurations);
            configStorage.Received().GetAll();
        }
    }
}
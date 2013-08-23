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
            var dependncyHelper = new DependenciesHelper();
            var textEditorService = dependncyHelper.CreateTextEditorServiceInstance();

            var configStorage = dependncyHelper.Resolve<IConfigurationsStorage>();
            const string configName = "configName";

            var configuration = Substitute.For<ITextEditorConfiguration>();
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
        }

        [TestMethod]
        public void CreateDocumentWithMissingConfugurationTest()
        {
            // Arrange
            var dependncyHelper = new DependenciesHelper();
            var textEditorService = dependncyHelper.CreateTextEditorServiceInstance();

            var configStorage = dependncyHelper.Resolve<IConfigurationsStorage>();
            const string configName = "configName";

            configStorage.GetAll()
                         .Returns(x => new ITextEditorConfiguration[] { });

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
        }

        [TestMethod]
        public void CanGetActiveDocument()
        {
            throw new System.NotImplementedException();
        }

        [TestMethod]
        public void CanRegisterHighlighting()
        {
            throw new System.NotImplementedException();
        }

        [TestMethod]
        public void CanGetConfigurations()
        {
            throw new System.NotImplementedException();
        }
    }
}
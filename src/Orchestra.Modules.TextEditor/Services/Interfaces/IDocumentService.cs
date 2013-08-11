// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDocumentService.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2013 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Orchestra.Modules.TextEditor.Services.Interfaces
{
    using Orchestra.Modules.TextEditor.Models;

    public interface IDocumentService
    {
        void Save(Document document);

        void SaveAs(Document document);

        void LoadFile(Document dovument, string pathToFile);

        void NewFile(Document dovument, string extension);
    }
}
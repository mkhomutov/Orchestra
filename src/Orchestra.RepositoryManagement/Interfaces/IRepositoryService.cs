// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepositoryService.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2012 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orchestra.RepositoryManagement.Interfaces
{
    using System;

    /// <summary>
    /// The repository service that allows you to load  repositories
    /// </summary>
    public interface IRepositoryService
    {
        void CloneRemoteToLocal(RepositoryConnectionInfo repInfo);
        void UpdateLocalFromRemote(RepositoryConnectionInfo repInfo);
        DateTime? GetLastRemoteCommitDate(RepositoryConnectionInfo repInfo);
        DateTime? GetLastLocalCommitDate(RepositoryConnectionInfo repInfo);

    }
}

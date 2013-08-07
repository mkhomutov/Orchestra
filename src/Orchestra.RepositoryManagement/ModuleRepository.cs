// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleRepository.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2012 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orchestra.RepositoryManagement
{
    using Interfaces;
    using System;

    public class ModuleRepository
    {
        private readonly RepositoryConnectionInfo _connectionInfo;
        private readonly IRepositoryService _repositoryService;


        public ModuleRepository(RepositoryConnectionInfo connectionInfo, IRepositoryService repositoryService)
        {
            _connectionInfo = connectionInfo;
            _repositoryService = repositoryService;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}

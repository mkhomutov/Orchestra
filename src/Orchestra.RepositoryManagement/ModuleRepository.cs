using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestra.RepositoryManagement
{
    using Interfaces;

    public class ModuleRepository
    {
        private readonly RepositoryConnectionInfo _connectionInfo;
        private readonly IRepositoryService _repositoryService;

      //  public DateTime? DateModified { get; }

        public ModuleRepository(RepositoryConnectionInfo connectionInfo, IRepositoryService repositoryService)
        {
            _connectionInfo = connectionInfo;
            _repositoryService = repositoryService;
        }

       /* public void Update()
        {
            if (true)
            {
                _repositoryService.Clone(_connectionInfo);
            }
            else
            {
                if (true)
                {
                    _repositoryService.Update(_connectionInfo);
                }
                else
                {
                    _repositoryService.GetLastCommitDate(_connectionInfo);
                }
            }
        }*/
    }
}

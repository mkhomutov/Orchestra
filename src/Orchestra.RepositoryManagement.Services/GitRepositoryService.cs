// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GitRepositoryService.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2012 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orchestra.RepositoryManagement.Services
{
    using Interfaces;
    using NGit.Api;
    using NGit.Errors;
    using NGit.Storage.File;
    using Sharpen;
    using System.Linq;
    using System;

    /// <summary>
    /// this class allow you to manage git - repository load
    /// </summary>
    public class GitRepositoryService : IRepositoryService
    {
        public void CloneRemoteToLocal(RepositoryConnectionInfo connectionInfo)
        {
            Git.CloneRepository()
               .SetURI(connectionInfo.LocalDirectory)
               .SetDirectory(new FilePath(connectionInfo.RemoteUrl))
               .SetBranch(connectionInfo.BranchName)
               .Call();
        }

        public void UpdateLocalFromRemote(RepositoryConnectionInfo repInfo)
        {
            try
            {
                Git.Open(repInfo.LocalDirectory)
                   .Pull()
                   .Call();
            }
            catch (RepositoryNotFoundException)
            {
                CloneRemoteToLocal(repInfo);
            }
        }

        public DateTime? GetLastRemoteCommitDate(RepositoryConnectionInfo repInfo)
        {
            var git = Git.Open(repInfo.LocalDirectory);

            var references = git.LsRemote()
                .SetHeads(true)
                .Call();

            var head = references.ElementAt(0);

            return null;
        }

        public DateTime? GetLastLocalCommitDate(RepositoryConnectionInfo repInfo)
        {
            var git = Git.Open(repInfo.LocalDirectory);
            var repository = git.GetRepository();

            var reader = new ReflogReader(repository, "HEAD");
            var lastRef = reader.GetLastEntry();

            if (lastRef == null)
                return null;

            var authorIdent = lastRef.GetWho();
            var authorDate = authorIdent.GetWhen();
            var timeZoneOffset = TimeSpan.FromMinutes(authorIdent.GetTimeZoneOffset());
            return authorDate + timeZoneOffset;
        }
    }
}


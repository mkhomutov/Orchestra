// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GitRepositoryServiceTest.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2012 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orchestra.RepositoryManagement.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Orchestra.RepositoryManagement.Services;

    [TestClass]
    public class GitRepositoryServiceTest
    {
        [TestMethod]
        public void GetLastLocalCommitDateTest()
        {
            var target = new GitRepositoryService();

            var repositoryInfo = new RepositoryConnectionInfo
            {
                BranchName = "master",
                LocalDirectory = @"D:\Projects\Sideline\Orchestra"
            };

            var date = target.GetLastLocalCommitDate(repositoryInfo);

        }
    }
}

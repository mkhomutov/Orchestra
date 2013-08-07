namespace Orchestra.RepositoryManagement.Services.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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

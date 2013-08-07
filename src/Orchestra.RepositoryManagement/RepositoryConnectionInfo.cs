
namespace Orchestra.RepositoryManagement
{
    /// <summary>
    /// provides an information needed to establish connection to repository
    /// </summary>
    public class RepositoryConnectionInfo
    {
        /// <summary>
        /// local repo directory
        /// </summary>
        public string LocalDirectory { get; set; }
        /// <summary>
        /// remote repo directory
        /// </summary>
        public string RemoteUrl { get; set; }
        public string BranchName { get; set; }
    }
}

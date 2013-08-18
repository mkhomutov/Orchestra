namespace Orchestra.Messages
{
    /// <summary>
    /// 
    /// </summary>
    public class ModuleInitialized
    {
        /// <summary>
        /// 
        /// </summary>
        public string ModuleName { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleName"></param>
        public ModuleInitialized(string moduleName)
        {
            ModuleName = moduleName;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orchestra.Modules
{
    /// <summary>
    /// Base type for all modules used by Orchestra, wich can be used in pair with isolated module.
    /// </summary>
    public abstract class IsolatedModuleProxy : ModuleBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IsolatedModuleProxy"/> class.
        /// </summary>
        /// <param name="moduleName">Name of the module.</param>
        protected IsolatedModuleProxy(string moduleName) : base(moduleName)
        {
        }
    }
}

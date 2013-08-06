using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orchestra.Modules
{
    /// <summary>
    /// Base class for all updatable modules used by Orchestra.
    /// </summary>
    public abstract class UpdatableModule : ModuleBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdatableModule"/> class.
        /// </summary>
        /// <param name="moduleName">Name of the module.</param>
        /// <exception cref="ArgumentException">The <paramref name="moduleName"/> is <c>null</c> or whitespace.</exception>
        public UpdatableModule(string moduleName)
            : base(moduleName)
        {
        }
    }
}

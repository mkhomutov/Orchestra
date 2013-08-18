using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orchestra.ModulesHost
{
    using CommandLine;

    internal class RunOptions
    {
        [Option('s', "shell"/*, DefaultValue = @"ipc://OrchestraShell"*/)]
        public string ShellChannel { get; set; }

        [Option('g', "guid")]
        public string ModulesHostGuid { get; set; }
    }
}

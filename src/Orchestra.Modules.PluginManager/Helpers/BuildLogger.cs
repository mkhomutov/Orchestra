using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orchestra.Modules.PluginManager.Helpers
{
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;

    internal class BuildLogger : Logger
    {
        private readonly StringBuilder errorLog = new StringBuilder();

        public string BuildErrors { get; private set; }

        public IList<string> BuildDetails { get; private set; }

        /// <summary>
        /// Initialize is guaranteed to be called by MSBuild at the start of the build
        /// before any events are raised.
        /// </summary>
        public override void Initialize(IEventSource eventSource)
        {
            BuildDetails = new List<string>();            

            eventSource.ProjectStarted += eventSource_ProjectStarted;
/*            eventSource.MessageRaised += eventSource_MessageRaised;
            eventSource.BuildStarted += eventSource_BuildStarted;
            eventSource.BuildFinished += eventSource_BuildFinished;*/
            eventSource.ErrorRaised += eventSource_ErrorRaised;

        }

        private void eventSource_ErrorRaised(object sender, BuildErrorEventArgs e)
        {
            var line = String.Format(": ERROR {0}({1},{2}): ", e.File, e.LineNumber, e.ColumnNumber);
            errorLog.Append(line + e.Message);
        }

        private void eventSource_ProjectStarted(object sender, ProjectStartedEventArgs e)
        {
            BuildDetails.Add(e.Message);
        }


        /// <summary>
        /// Shutdown() is guaranteed to be called by MSBuild at the end of the build, after all
        /// events have been raised.
        /// </summary>
        public override void Shutdown()
        {
            BuildErrors = errorLog.ToString();
        }
    }
}

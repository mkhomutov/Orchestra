namespace Orchestra.ModuleManager.Common.Updating.SourceManagement
{
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.Build.Evaluation;
    using Microsoft.Build.Execution;
    using Microsoft.Build.Framework;

    public class SolutionBuilder
    {
        private readonly FileInfo solution;

        private readonly DirectoryInfo outputDir;

        private readonly BuildLogger logger = new BuildLogger();

        public SolutionBuilder(string pathToSolution, string outputPath)
        {
            this.solution = new FileInfo(pathToSolution);

            this.outputDir = new DirectoryInfo(outputPath);
        }

        public bool Build()
        {
            var projectCollection = new ProjectCollection();

            var globalProperty = new Dictionary<string, string> { { "OutputPath", outputDir.FullName } };

            var parameters = new BuildParameters(projectCollection) { Loggers = new ILogger[] { this.logger } };

            var buidlRequest = new BuildRequestData(solution.FullName, globalProperty, "4.0", new[] { "Build" }, null);

            var buildResult = BuildManager.DefaultBuildManager.Build(parameters, buidlRequest);

            return buildResult.OverallResult == BuildResultCode.Success;
        }

        public IList<string> Details
        {
            get
            {
                return this.logger.BuildDetails;
            }
        }

        public string Errors 
        {
            get
            {
                return this.logger.BuildErrors;
            }
        }
    }
}

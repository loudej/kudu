﻿using System.Configuration;
using System.IO;

namespace Kudu.TestHarness
{
    internal static class PathHelper
    {
        // Hard code the path to the services site (makes it easier to debug)
        internal static readonly string ServiceSitePath = ConfigurationManager.AppSettings["serviceSitePath"] ?? Path.GetFullPath(@"..\..\..\Kudu.Services.Web");
        internal static readonly string SitesPath = ConfigurationManager.AppSettings["sitesPath"] ?? Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "apps"));

        // Test paths
        internal static readonly string TestsRootPath = Path.Combine(Directory.GetCurrentDirectory(), "Tests");
        internal static readonly string LocalRepositoriesDir = Path.GetFullPath(Path.Combine(TestsRootPath, "TestRepositories"));
        internal static readonly string TestResultsPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "TestResults"));
        internal static readonly string ZippedRepositoriesDir = Path.Combine(@"..\..\ZippedRepositories");
        internal static readonly string GitDeploymentTestsFile = Path.Combine(@"..\..\GitDeploymentTests.csv");

    }
}
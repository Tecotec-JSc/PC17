using System;
using System.IO;

namespace T3ACS.UITests.Config
{
    /// <summary>Every path the suite touches, in one place. See HUONG_DAN_AUTOMATION.md section 2
    /// for why the app under test has to be an isolated copy, not the dev instance.</summary>
    public static class TestConfig
    {
        /// <summary>Override via the T3ACS_UI_TEST_APP_DIR environment variable for machines
        /// (CI runners, other dev machines) that don't use D:\T3ACS\UITestApp.</summary>
        public static readonly string AppDir =
            Environment.GetEnvironmentVariable("T3ACS_UI_TEST_APP_DIR") ?? @"D:\T3ACS\UITestApp";

        public static readonly string ExePath = Path.Combine(AppDir, "T3ACS.exe");
        public static readonly string DbPath = Path.Combine(AppDir, "T3.db");
        public static readonly string ShotsDir = Path.Combine(AppDir, "_screens");
    }
}

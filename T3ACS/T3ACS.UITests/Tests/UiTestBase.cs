using System.Runtime.CompilerServices;
using T3ACS.UITests.Config;
using T3ACS.UITests.Core;
using T3ACS.UITests.Data;

namespace T3ACS.UITests.Tests
{
    /// <summary>Shared per-test setup: every UI test needs a clean, seeded, isolated app
    /// instance. xUnit constructs the test class fresh for each [Fact], so this constructor runs
    /// before every test automatically - no [SetUp]/fixture wiring needed.</summary>
    public abstract class UiTestBase
    {
        protected UiTestBase()
        {
            ProcessCleanup.KillStrayInstances(TestConfig.ExePath);
            TestDataSeeder.Seed(TestConfig.DbPath);
        }

        /// <summary>testName defaults to the calling [Fact] method's name - it namespaces this
        /// run's screenshots (see Screenshotter) so tests never overwrite each other's images.
        /// Only pass it explicitly if a test needs multiple sessions in one [Fact].</summary>
        protected static T3AcsSession LaunchApp([CallerMemberName] string testName = "") =>
            T3AcsSession.Launch(TestConfig.ExePath, TestConfig.ShotsDir, testName);
    }
}

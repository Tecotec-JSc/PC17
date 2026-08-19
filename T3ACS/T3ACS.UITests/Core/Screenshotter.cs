using System;
using System.IO;
using FlaUI.Core.AutomationElements;

namespace T3ACS.UITests.Core
{
    /// <summary>Numbered screenshots for a single test run, written under
    /// &lt;shotsDir&gt;/&lt;testName&gt;/ so two test classes writing to the same ShotsDir don't
    /// overwrite each other's 01_..., 02_... files.</summary>
    public class Screenshotter
    {
        private readonly string _dir;
        private int _index;

        public Screenshotter(string shotsDir, string testName)
        {
            _dir = string.IsNullOrEmpty(testName) ? shotsDir : Path.Combine(shotsDir, SanitizeForPath(testName));
        }

        public void Take(AutomationElement window, string label)
        {
            try
            {
                Directory.CreateDirectory(_dir);
                _index++;
                var path = Path.Combine(_dir, $"{_index:D2}_{label}.png");
                var img = FlaUI.Core.Capturing.Capture.Element(window);
                img.ToFile(path);
                Console.WriteLine("Screenshot: " + path);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Screenshot failed: " + ex.Message);
            }
        }

        private static string SanitizeForPath(string name)
        {
            foreach (var c in Path.GetInvalidFileNameChars())
            {
                name = name.Replace(c, '_');
            }
            return name;
        }
    }
}

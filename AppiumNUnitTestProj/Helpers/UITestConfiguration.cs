using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace AppiumNUnitTestProj.Helpers
{
    public class UITestConfiguration
    {
        private static Lazy<UITestConfiguration> _lazyConfiguration =
            new Lazy<UITestConfiguration>(() => GetConfiguration());
        private static UITestConfiguration _current;

        public static UITestConfiguration Current => _current ?? (_current = _lazyConfiguration.Value);

        public string Platform { get; set; }

        public Uri AppiumServer { get; set; }

        public Dictionary<string, string> Capabilities { get; set; }

        private static UITestConfiguration GetConfiguration()
        {
            var assembly = typeof(UITestConfiguration).Assembly;
            using (var stream = assembly.GetManifestResourceStream("config.json"))
            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<UITestConfiguration>(json);
            }
        }
    }
}

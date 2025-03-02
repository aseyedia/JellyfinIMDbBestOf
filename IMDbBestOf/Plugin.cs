using System;
using System.Collections.Generic;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;

namespace IMDbBestOf
{
    public class Plugin : BasePlugin<PluginConfiguration>, IHasWebPages
    {
        public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer)
            : base(applicationPaths, xmlSerializer)
        {
            Instance = this;
        }

        // Holds the current plugin instance.
        public static Plugin Instance { get; private set; }

        // The plugin's display name.
        public override string Name => "IMDb Best Of";

        // Replace with a new GUID generated for your plugin.
        public override Guid Id => Guid.Parse("6e06042c-4b40-4964-a40d-aeeb720d4071");

        // If you have a configuration page, list it here.
        public IEnumerable<PluginPageInfo> GetPages()
        {
            return new PluginPageInfo[]
            {
                new PluginPageInfo
                {
                    Name = "IMDb Best Of",
                    // When adding a config page, embed your HTML file as a resource.
                    EmbeddedResourcePath = "IMDbBestOf.Configuration.configPage.html"
                }
            };
        }
    }
}

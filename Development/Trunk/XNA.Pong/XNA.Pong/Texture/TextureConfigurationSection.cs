using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace XNA.Pong.Texture
{
    public class TextureConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("name")]
        public string Name
        {
            get { return this["name"] as string; }
        }

        [ConfigurationProperty("assetName")]
        public string AssetName
        {
            get { return this["assetName"] as string; }
        }
    }
}

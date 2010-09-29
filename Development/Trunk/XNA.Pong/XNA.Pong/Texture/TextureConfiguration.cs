using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace XNA.Pong.Texture
{
    public class TextureConfiguration:ConfigurationSection
    {
        /// <summary>
        /// Gets the hosts.
        /// </summary>
        /// <value>The hosts.</value>
        [ConfigurationProperty("textures")]
        public TextureConfigurationElementCollection Textures
        {
            get
            {
                return this["textures"] as TextureConfigurationElementCollection;
            }
        }
    }
}

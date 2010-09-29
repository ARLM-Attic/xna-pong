using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace XNA.Pong.Texture
{
    public class TextureConfigurationHandler
    {
        public static TextureConfiguration Instance 
        {
            get { return System.Configuration.ConfigurationManager.GetSection("textureConfiguration") as TextureConfiguration; }
        }
    }
}

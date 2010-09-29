using Microsoft.Xna.Framework.Graphics;

namespace Game.Base
{
    public interface ITexture
    {
        string AssetName { get; set; }
        Texture TextureBase { get; }
        void LoadContent();
        void UnloadContent();
    }
}
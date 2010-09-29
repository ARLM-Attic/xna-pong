using Microsoft.Xna.Framework;

namespace Game.Base
{
    public interface IGameComponent
    {
        void LoadContent();
        void UnloadContent();
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
    }
}
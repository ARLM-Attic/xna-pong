using Microsoft.Xna.Framework;

namespace Game.Base
{
    public interface IGameState:IGame
    {
        void LoadContent();
        void UnloadContent();
        void Update(GameTime gameTime, bool otherScreenHasFocus, bool coverByOtherScreen);
        void Draw(GameTime gameTime);

        GameStateTypes GameState { get; set; }
        bool IsPopup { get; set; }
    }
}

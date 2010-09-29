using System;
using Game.Base;
using Microsoft.Xna.Framework;
using XNA.Pong.Scenes;

namespace XNA.Pong.GameState
{
    public class InitializingGameState : GameStateBase
    {
        private IScene _initializingScreen;
        
        public InitializingGameState(Microsoft.Xna.Framework.Game game):base(game)
        {
            _initializingScreen = new InitializingScene(game);
        }

        #region Overrides of GameStateBase

        public override void LoadContent()
        {
            _initializingScreen.LoadContent();
        }

        public override void UnloadContent()
        {
            _initializingScreen.UnloadContent();
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coverByOtherScreen)
        {
            _initializingScreen.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _initializingScreen.Draw(gameTime);
        }

        #endregion
    }
}
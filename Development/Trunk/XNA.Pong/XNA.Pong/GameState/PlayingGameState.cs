using System;
using Game.Base;
using Microsoft.Xna.Framework;
using XNA.Pong.Scenes;

namespace XNA.Pong.GameState
{
    public class PlayingGameState : GameStateBase
    {

        #region Fields

        private PlayingScene _playingScene;

        #endregion

        #region Ctors

        public PlayingGameState(Microsoft.Xna.Framework.Game game):base(game)
        {
            _playingScene = new PlayingScene(Game);
        }

        #endregion

        #region Overrides of GameStateBase

        public override void LoadContent()
        {
            _playingScene.LoadContent();
        }

        public override void UnloadContent()
        {
            _playingScene.UnloadContent();
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coverByOtherScreen)
        {
            _playingScene.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _playingScene.Draw(gameTime);
        }

        #endregion
    }
}

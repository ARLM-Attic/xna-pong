using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game.Base
{
    public abstract class GameStateBase: IGameState
    {
        protected GameStateBase(Microsoft.Xna.Framework.Game game)
        {
            Game = game;
        }

        #region Implementation of IGameState

        public abstract void LoadContent();
        public abstract void UnloadContent();
        public abstract void Update(GameTime gameTime, bool otherScreenHasFocus, bool coverByOtherScreen);
        public abstract void Draw(GameTime gameTime);

        public GameStateTypes GameState { get; set; }
        public bool IsPopup { get; set; }

        /// <summary>
        /// Gets the game.
        /// </summary>
        /// <value>The game.</value>
        public Microsoft.Xna.Framework.Game Game { get; set; }

        #endregion
    }
}

using Game.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace XNA.Pong.Input
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class KeyboardInputBase:IInput
    {
        private GameTime _gameTime;
        private KeyboardState _previousState;
        private KeyboardState _currentState;
        private IEntity _entity;

        public void Update(IEntity entity, GameTime gameTime)
        {
            CurrentState = Keyboard.GetState();
            GameTime = gameTime;
            Entity = entity;

            OnUpdate();

            PreviousState = CurrentState;
        }

        /// <summary>
        /// Called when [update].
        /// 
        /// Handler hook to simplify management of states. The base class manages the state
        /// </summary>
        public virtual void OnUpdate() {}

        #region Properties

        public KeyboardState PreviousState
        {
            get { return _previousState; }
            set { _previousState = value; }
        }

        public KeyboardState CurrentState
        {
            get { return _currentState; }
            set { _currentState = value; }
        }

        public GameTime GameTime
        {
            get { return _gameTime; }
            set { _gameTime = value; }
        }

        public IEntity Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }

        #endregion

    }
}
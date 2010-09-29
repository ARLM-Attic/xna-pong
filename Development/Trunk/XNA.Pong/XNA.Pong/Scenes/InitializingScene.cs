using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XNA.Pong.GameState;

namespace XNA.Pong.Scenes
{

    public class MainMenuItem
    {
        public MainMenuItem(string text, Vector2 position, Color color, Color selectedColor)
        {
            Text = text;
            Position = position;
            Color = color;
            SelectedColor = selectedColor;
        }

        public string Text { get; set; }
        public Vector2 Position { get; set; }
        public Color Color { get; set; }
        public Color SelectedColor { get; set; }

        
    }


    public class InitializingScene: SceneBase
    {
        private SpriteFont _font;
        private KeyboardState _currentKeyboardState;
        private KeyboardState _previousKeyboardState;
        private IList<MainMenuItem> _menuItems;
        private int _selectedItemIndex;
        private float _updateInterval = 0.1f;
        private float _timeSinceLastUpdate = 0.0f;

        public InitializingScene(Microsoft.Xna.Framework.Game game) : base(game)
        {
            _menuItems = new List<MainMenuItem>();
            _menuItems.Add(new MainMenuItem("Play game", new Vector2(200, 100), Color.Red, Color.Yellow));
            _menuItems.Add(new MainMenuItem("Help", new Vector2(200, 150), Color.Red, Color.Yellow));
            _menuItems.Add(new MainMenuItem("Quit", new Vector2(200, 200), Color.Red, Color.Yellow));
        }

        #region Overrides of SceneBase

        public override void LoadContent()
        {
            _font = Game.Content.Load<SpriteFont>("SpriteFont1");
            
        }

        public override void UnloadContent()
        {
            
        }

        public void UpdateSelectedItem(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _timeSinceLastUpdate += elapsed;

            if (_timeSinceLastUpdate < _updateInterval)
            {
                return;
            }

            if (IsSelected())
            {
                if (_selectedItemIndex == 0)
                {
                    // start game
                    GameStateManager gameStateManager = (GameStateManager)Game.Services.GetService(typeof(GameStateManager));
                    gameStateManager.AddGameState(new PlayingGameState(Game));
                }
                if (_selectedItemIndex == 1)
                {
                    // show help
                }
                if (_selectedItemIndex == 2)
                {
                    Game.Exit();
                }
            }

            if( IsMovingUp() )
            {
                _selectedItemIndex--;
            }

            if(IsMovingDown())
            {
                _selectedItemIndex++;
            }
            

            if( _selectedItemIndex < 0 )
            {
                _selectedItemIndex = _menuItems.Count-1;
            }

            if(_selectedItemIndex >= _menuItems.Count)
            {
                _selectedItemIndex = 0;
            }

            _timeSinceLastUpdate -= _updateInterval;
        }

        public override void Update(GameTime gameTime)
        {
            _currentKeyboardState = Keyboard.GetState();



            UpdateSelectedItem(gameTime);

            _previousKeyboardState = Keyboard.GetState();
        }

        private bool IsMovingUp()
        {
            return _currentKeyboardState.IsKeyDown(Keys.Up);
        }

        private  bool IsMovingDown()
        {
            return _currentKeyboardState.IsKeyDown(Keys.Down);
        }
        private bool IsSelected()
        {
            return _currentKeyboardState.IsKeyDown(Keys.Enter);
        }

        public override void Draw(GameTime gameTimet)
        {
            SpriteBatch.Begin();

            for (int i = 0; i < _menuItems.Count; i++ )
            {
                SpriteBatch.DrawString(_font, _menuItems[i].Text, _menuItems[i].Position, GetColorForItem(i));
            }
            
            
            SpriteBatch.End();

        }

        public Color GetColorForItem(int index)
        {
            return index == _selectedItemIndex ? _menuItems[index].SelectedColor : _menuItems[index].Color;
        }

        #endregion
    }
}

using Game.Base;
using Microsoft.Xna.Framework;

namespace XNA.Pong.Entities
{
    public class Entity:EntityBase,IFocusable
    {
        #region Fields

        #endregion

        #region Ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        internal Entity(IInput input, IGraphic graphics, Microsoft.Xna.Framework.Game game):base(input, graphics, game)
        {
            Position = new Vector2(0,0);
        }

        #endregion


        #region Properties


        #endregion

        #region Methods


        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            
        }



        #endregion
    }
}
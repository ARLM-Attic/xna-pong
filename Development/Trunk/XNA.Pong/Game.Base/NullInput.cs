using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game.Base
{
    /// <summary>
    /// This is a NullInput class when no input management is necessary
    /// </summary>
    public class NullInput:IInput
    {
        /// <summary>
        /// Performs nothing since this is a NULL class.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="gameTime">The game time.</param>
        public void Update(IEntity entity, GameTime gameTime){}
    }
}

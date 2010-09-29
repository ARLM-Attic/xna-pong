using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Base
{
    /// <summary>
    /// NullGraphics class to be used when no graphics class is necessary.
    /// </summary>
    public class NullGraphics:IGraphic
    {
        /// <summary>
        /// Performs nothing since this is a null Graphics class.
        /// </summary>
        /// <param name="sprite">The sprite.</param>
        public void Draw(IEntity sprite)
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game.Base
{
    public interface IInput
    {
        void Update(IEntity entity, GameTime gameTime);
    }
}

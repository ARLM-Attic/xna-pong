using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Base;
using Microsoft.Xna.Framework.Graphics;

namespace XNA.Pong.Entities
{
    public class CircleDebugEntity:EntityBase
    {
        public CircleDebugEntity(IInput input, IGraphic graphics, Microsoft.Xna.Framework.Game game) : base(input, graphics, game)
        {
        }
    }
}

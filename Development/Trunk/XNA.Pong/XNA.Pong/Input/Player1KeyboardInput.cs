using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace XNA.Pong.Input
{
    public class Player1KeyboardInput:PadelKeyboardInput
    {
        public override bool IsMovingUp()
        {
            return CurrentState.IsKeyDown(Keys.Q);
        }

        public override bool IsMovingDown()
        {
            return CurrentState.IsKeyDown(Keys.A);
        }
    }
}

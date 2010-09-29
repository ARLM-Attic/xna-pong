using System;
using Microsoft.Xna.Framework;

namespace XNA.Pong.Input
{
    public abstract class PadelKeyboardInput : KeyboardInputBase
    {
        private const int PadelSpeed = 160;
        private static readonly Vector2 MoveUp = new Vector2(0, -1);
        private static readonly Vector2 MoveDown = new Vector2(0, 1);
        private static readonly Vector2 Velocity = new Vector2(PadelSpeed, 500);


        public override void OnUpdate()
        {
            if (IsMovingDown())
            {
                Entity.Position += MoveDown * Velocity *(float) GameTime.ElapsedGameTime.TotalSeconds;
            }

            if( IsMovingUp())
            {
                Entity.Position += MoveUp * Velocity * (float)GameTime.ElapsedGameTime.TotalSeconds;
            }

            if( Entity.Position.Y < 0 )
            {
                Entity.Position = new Vector2(Entity.Position.X, 0 );
            }
            if( Entity.Position.Y+Entity.Size.Height > Entity.Game.GraphicsDevice.Viewport.Height )
            {
                Entity.Position = new Vector2(Entity.Position.X, Entity.Game.GraphicsDevice.Viewport.Height - Entity.Size.Height);
            }
        }

        public abstract bool IsMovingUp();
        public abstract bool IsMovingDown();

    }
}

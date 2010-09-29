using System;
using Game.Base;

namespace XNA.Pong
{
    public class CollisionEventArgs:EventArgs
    {
        public CollisionEventArgs(IEntity collisionWithEntity)
        {
            CollisionWithEntity = collisionWithEntity;
        }

        public IEntity CollisionWithEntity { get; set; }

    }
}
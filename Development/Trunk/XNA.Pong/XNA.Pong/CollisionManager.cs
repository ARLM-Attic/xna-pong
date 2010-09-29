using Game.Base;
using Microsoft.Xna.Framework;
using XNA.Pong.Input;

namespace XNA.Pong
{
    public class CollisionManager
    {
        public event CollisionEventHandler Collision;

        protected virtual void OnCollision(CollisionEventArgs s)
        {

            // insert code so that event is only triggered to correct entities
            if (Collision != null)
            {
                Collision(this, s);
            }
        }

        public void PerformCollisionCheck(IEntity entityA, IEntity entityB)
        {
            Rectangle a = GetBoundingBox(entityA);
            Rectangle b = GetBoundingBox(entityB);

            if (PerformCollisionCheck(a, b))
            {
                Collision(null, new CollisionEventArgs(entityB));
            }
        }

        public bool PerformCollisionCheck(Rectangle a, Rectangle b)
        {
            return a.Intersects(b);
        }

        public Rectangle GetBoundingBox(IEntity entity)
        {
            return new Rectangle((int)entity.Position.X, (int)entity.Position.Y, entity.Size.Width, entity.Size.Height);
        }


    }
}
using Game.Base;
using Microsoft.Xna.Framework;

namespace XNA.Pong.Input
{
    public interface IBallState
    {
        void Update(IEntity entity, GameTime gameTime, BallInput ballInput);
    }
}
using System;


namespace Game.Base
{
    public interface IEntityFactory
    {
        IEntity CreateSprite(string type);
    }
}

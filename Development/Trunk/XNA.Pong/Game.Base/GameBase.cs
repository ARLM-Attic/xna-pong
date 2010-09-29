using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Game.Base.Configuration;
using Microsoft.Xna.Framework;
using Component = Game.Base.Configuration.Component;

namespace Game.Base
{
    public class GameBase:Microsoft.Xna.Framework.Game
    {
        public GameBase()
        {
            PrepareManagers();
            PrepareComponents(); 
        }

        private void PrepareManagers()
        {
            foreach (Manager manager in ConfigurationManager.Instance.Managers)
            {
                GameComponent baseManager =
                    ManagerActivator.CreateInstance(Type.GetType(manager.Value), this) as GameComponent;
                Components.Add(baseManager);
                Services.AddService(Type.GetType(manager.InterfaceType), baseManager);
            }
        }

        private void PrepareComponents()
        {
            foreach (Component component in ConfigurationManager.Instance.Components)
            {
                GameComponent baseComponent = ComponentActivator.CreateInstance(Type.GetType(component.Value), this) as GameComponent;
                Components.Add(baseComponent);
            }
        }
       



    }
}

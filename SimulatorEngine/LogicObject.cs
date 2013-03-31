using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulatorEngine
{
    public class LogicObject : GameObject
    {
        protected override void preChildrenUpdate(float deltaTime)
        {
            runPreLogic(deltaTime);
        }

        protected override void postChildrenUpdate(float deltaTime)
        {
            runPostLogic(deltaTime);
        }

        protected virtual void runPreLogic(float deltaTime)
        { 
            
        }

        protected virtual void runPostLogic(float deltaTime)
        {

        }
    }
}

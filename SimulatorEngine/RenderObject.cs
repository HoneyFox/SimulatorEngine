using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulatorEngine
{
	public class RenderObject : GameObject
    {
        protected override void preChildrenUpdate(float deltaTime)
        {
            updateRenderObject(deltaTime);
        }

        protected virtual void updateRenderObject(float deltaTime)
        {
            
        }

        public override void render()
        {
            this.doRender();
            base.render();
        }

        protected virtual void doRender()
        { 
        
        }
    }
}

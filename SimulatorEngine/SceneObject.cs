using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulatorEngine
{
	public class SceneObject : GameObject
    {
        LogicObject m_mainLogicObj;
        RenderObject m_mainRenderObj;

        public SceneObject(LogicObject mainLogicObj = null, RenderObject mainRenderObj = null)
        {
            m_mainLogicObj = mainLogicObj;
            m_mainRenderObj = mainRenderObj;
        }

        protected virtual void runPreScene(float deltaTime)
        {

        }

        protected virtual void runPostScene(float deltaTime)
        {

        }
    }
}

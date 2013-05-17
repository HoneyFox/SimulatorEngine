using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimulatorEngine;

namespace NavalWarfare
{
    public class BuoyancyLogic : LogicObject
    {
        public SimplePhysicsLogic p_simplePhysicsLogic
        {
            get;
            set;
        }
        public ConstantForce m_BuoyancyForce;
        public BuoyancyLogic(GameObject parentObj = null)
		{
			m_parentObject = parentObj;
			m_attributes.Add("SinkBuoyancy", 10000.0f);
			if (m_parentObject is SimplePhysicsLogic)
			{
				p_simplePhysicsLogic = (m_parentObject as SimplePhysicsLogic);
                p_simplePhysicsLogic.addConstanceForce(m_BuoyancyForce);
			}
			else
			{
				p_simplePhysicsLogic = null;
			}
		}
        protected override void runPostLogic(float deltaTime)
		{
            if (p_simplePhysicsLogic != null&&!m_parentObject.findGameObjectOfType<DamageLogic>().isOperational())
			{
				m_BuoyancyForce.force=-(UnityEngine.Vector3.up)*(int)m_attributes["SinkBuoyancy"];
			}
            
    }
}

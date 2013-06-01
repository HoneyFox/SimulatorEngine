using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimulatorEngine;

namespace NavalWarfare
{
    class CatapultLogic : LogicObject
    {
        public SimplePhysicsLogic p_simplePhysicsLogic
        {
            get;
            set;
        }
        public ConstantForce m_CatapultForce;
        public float m_CatapultLength;
        public float ActiveLength = 0.0f;
        bool Actived = false;
        UnityEngine.Vector3 p_velocity;
        public CatapultLogic(GameObject parentObj = null)
		{
			m_parentObject = parentObj;
            m_attributes.Add("CatapultForce", 10000.0f);
            m_attributes.Add("CatapultLength", 10000.0f);
			if (m_parentObject is SimplePhysicsLogic)
			{
				p_simplePhysicsLogic = (m_parentObject as SimplePhysicsLogic);
                p_simplePhysicsLogic.addConstanceForce(m_CatapultForce);
			}
			else
			{
				p_simplePhysicsLogic = null;
			}
		}

        protected override void runPostLogic(float deltaTime)
        {
            if (m_parentObject is SimplePhysicsLogic)
            {
                p_velocity = p_simplePhysicsLogic.m_velocity;
                if (Actived && ActiveLength < m_CatapultLength)
                {
                    ActiveLength += deltaTime;
                    if (p_simplePhysicsLogic != null)
                    {
                        m_CatapultForce.force = (p_velocity) * (int)m_attributes["CatapultForce"];
                    }
                }
                if (ActiveLength >= m_CatapultLength)
                    Actived = false;
            }
        }
        public void Active()
        {
            Actived = true;
        }
    }
}

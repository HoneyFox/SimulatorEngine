using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimulatorEngine;

namespace NavalWarfare
{
    class RadarLogic : SensorLogic
    {
        public RadarLogic(GameObject parentObj = null)
        {
            m_attributes.Add("RadarEfficiencyFactor", 1.0f);
            m_attributes.Add("DetectionThreshold", 1.0f);
        }
        protected override void runPreLogic(float deltaTime)
        {
            base.runPreLogic(deltaTime);
            foreach (SensorContactLogic contact in m_contacts)
            {
                SimplePhysicsLogic physicsLogic = contact.mTarget.findGameObjectOfType<TypeLogic>().findGameObjectOfType<SimplePhysicsLogic>();
                float distanceSqr = ((m_parentObject.m_parentObject.findGameObjectOfType<SimplePhysicsLogic>().m_position - physicsLogic.m_position)).sqrMagnitude;
				
				// Remove targets that cannot be detected.
				if ((physicsLogic.m_radarCrossSection * (float)m_attributes["RadarEfficiencyFactor"]) / (distanceSqr * distanceSqr) < (float)m_attributes["DetectionThreshold"])
					m_contacts.Remove(contact);
            }
        }

    }
}

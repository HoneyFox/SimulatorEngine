using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimulatorEngine;

namespace NavalWarfare.LogicObjects
{
    class RadarLogic : SensorLogic
    {
        public List<SensorContactLogic> m_detections = new List<SensorContactLogic>();
        public RadarLogic(GameObject parentObj = null)
        {
            m_attributes.Add("RadarEfficiencyFactor", 1.0f);
            m_attributes.Add("DetectionTransmitPower", 1.0f);
        }
        protected override void runPreLogic(float deltaTime)
        {
            base.runPreLogic(deltaTime);
            foreach (SensorContactLogic contact in m_contacts)
            {
                
                SimplePhysicsLogic physicsLogic = contact.mTarget.findGameObjectOfType<TypeLogic>().findGameObjectOfType<SimplePhysicsLogic>();
                float Distance = ((m_parentObject.m_parentObject.findGameObjectOfType<SimplePhysicsLogic>().m_position - physicsLogic.m_position)).sqrMagnitude;
                if ((physicsLogic.m_ReflectionArea * (float)m_attributes["RadarEfficiencyFactor"] )/(Distance*Distance)> (float)m_attributes["DetectionTransmitPower"])
                    m_detections.Add(contact);
            }
        }

    }
}

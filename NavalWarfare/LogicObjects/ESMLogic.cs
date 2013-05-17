using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimulatorEngine;

namespace NavalWarfare
{
    class ESMLogic:SensorLogic
    {
        public ESMLogic(GameObject parentObj = null)
        {
            m_attributes.Add("DetectionThreshold", 1.0f);

        }
        public void ScoutedBy(RadarLogic Radar)
        {
            m_contacts.Add((SensorContactLogic)Radar.m_parentObject);
        }
    }
}

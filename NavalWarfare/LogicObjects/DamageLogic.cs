using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimulatorEngine;

namespace NavalWarfare
{
    class DamageLogic : LogicObject
    {
        public float currentHealthPoint;
        public DamageLogic(GameObject parentObj = null)
        {
            m_parentObject = parentObj;
            m_attributes.Add("maxHealthPoint", 100.0f);
            currentHealthPoint = (float)m_attributes["maxHealthPoint"];
        }
        public bool isOperational()
        {
            return ( currentHealthPoint> 0);
        }
        public void revoveryHealth(float value)
        {
            currentHealthPoint += value;
        }
        public void damageHealth(float value)
        {
            currentHealthPoint -= value;
        }
    }
}

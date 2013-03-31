using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimulatorEngine;

namespace NavalWarfare
{
	public class JetEngineLogic : PropulsionLogic
	{
		public float m_fuelFlow = 0.0f;

		public JetEngineLogic(GameObject parentObj = null)
		{
			m_attributes.Add("SpecificImpulse", 2100.0f);
			m_attributes.Add("FuelAmount", 100.0f);

			m_parentObject = parentObj;
			if (m_parentObject is SimplePhysicsLogic)
			{
				p_simplePhysicsLogic = (m_parentObject as SimplePhysicsLogic);
				p_simplePhysicsLogic.m_mass += (float)m_attributes["FuelAmount"];
			}
			else
			{
				p_simplePhysicsLogic = null;
			}
		}

		protected override void runPostLogic(float deltaTime)
		{
			base.runPostLogic(deltaTime);
			m_fuelFlow = m_thrust / (float)m_attributes["SpecificImpulse"];
			m_attributes["FuelAmount"] = (float)m_attributes["FuelAmount"] - m_fuelFlow * deltaTime;
			if ((float)m_attributes["FuelAmount"] <= 0)
			{
				m_thrust = 0.0f;
				m_throttle = 0.0f;
				m_thrustForce.force *= 0.0f;
			}

			if (p_simplePhysicsLogic != null)
			{
				p_simplePhysicsLogic.m_mass -= m_fuelFlow * deltaTime;
			}
		}
	}
}

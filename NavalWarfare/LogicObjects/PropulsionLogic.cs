using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimulatorEngine;

namespace NavalWarfare
{
	public class PropulsionLogic : LogicObject
	{
		public SimplePhysicsLogic p_simplePhysicsLogic
		{
			get;
			set;
		}

		public ConstantForce m_thrustForce = new ConstantForce(new UnityEngine.Vector3(0.0f, 0.0f, 0.0f));
		public UnityEngine.Vector3 m_thrustDirectionVector = UnityEngine.Vector3.forward;
		public float m_thrust = 0.0f;
		
		public float m_throttle = 0.0f;

		public PropulsionLogic(GameObject parentObj = null)
		{
			m_attributes.Add("MaxThrust", 4500.0f);
			
			m_parentObject = parentObj;
			if (m_parentObject is SimplePhysicsLogic)
			{
				p_simplePhysicsLogic = (m_parentObject as SimplePhysicsLogic);
				p_simplePhysicsLogic.addConstanceForce(m_thrustForce);
			}
			else
			{
				p_simplePhysicsLogic = null;
			}
		}

		protected override void runPostLogic(float deltaTime)
		{
			m_throttle = UnityEngine.Mathf.Clamp01(m_throttle);
			m_thrust = (float)m_attributes["MaxThrust"] * m_throttle;

			if (p_simplePhysicsLogic != null)
			{
				m_thrustDirectionVector = p_simplePhysicsLogic.m_velocity.normalized;
			}
			m_thrustForce.force = m_thrust * m_thrustDirectionVector;
		}
	}
}

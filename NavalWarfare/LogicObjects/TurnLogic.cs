using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimulatorEngine;

namespace NavalWarfare
{
	public class TurnLogic : LogicObject
	{
		public SimplePhysicsLogic p_simplePhysicsLogic
		{
			get;
			protected set;
		}

		public ConstantForce m_liftForce = new ConstantForce(new UnityEngine.Vector3(0.0f, 0.0f, 0.0f));
		public UnityEngine.Vector3 m_liftDirectionVector = UnityEngine.Vector3.up;
		public float m_lift = 0.0f;

		public ConstantForce m_sideForce = new ConstantForce(new UnityEngine.Vector3(0.0f, 0.0f, 0.0f));
		public UnityEngine.Vector3 m_sideDirectionVector = UnityEngine.Vector3.right;
		public float m_side = 0.0f;

		public float m_density = 1.29f;

		public float m_desiredYawRate = 0.0f;
		public float m_desiredPitchRate = 0.0f;

		public TurnLogic(GameObject parentObj = null)
		{ 
			m_parentObject = parentObj;
			if (m_parentObject is SimplePhysicsLogic)
			{
				p_simplePhysicsLogic = (m_parentObject as SimplePhysicsLogic);
				p_simplePhysicsLogic.addConstanceForce(m_liftForce);
				p_simplePhysicsLogic.addConstanceForce(m_sideForce);
			}
			else
			{
				p_simplePhysicsLogic = null;
			}

			m_parentObject = parentObj;
			m_attributes.Add("YawRate", 0.45f);
			m_attributes.Add("PitchRate", 0.45f);
		}

		protected override void runPreLogic(float deltaTime)
		{
			if (p_simplePhysicsLogic != null)
			{
				m_desiredYawRate = UnityEngine.Mathf.Min(m_desiredYawRate, (float)m_attributes["YawRate"]);
				m_side = p_simplePhysicsLogic.m_mass * m_desiredYawRate * p_simplePhysicsLogic.m_velocity.magnitude;
				m_sideDirectionVector = p_simplePhysicsLogic.m_rotation * UnityEngine.Vector3.right;

				m_desiredPitchRate = UnityEngine.Mathf.Min(m_desiredPitchRate, (float)m_attributes["PitchRate"]);
				m_lift = p_simplePhysicsLogic.m_mass * m_desiredPitchRate * p_simplePhysicsLogic.m_velocity.magnitude;
				m_liftDirectionVector = -(p_simplePhysicsLogic.m_rotation * UnityEngine.Vector3.up);
			}
			m_sideForce.force = m_side * m_sideDirectionVector;
			m_liftForce.force = m_lift * m_liftDirectionVector;
		}
	}
}

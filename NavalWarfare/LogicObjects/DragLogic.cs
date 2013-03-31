using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimulatorEngine;

namespace NavalWarfare
{
	public class DragLogic : LogicObject
	{
		public SimplePhysicsLogic p_simplePhysicsLogic
		{
			get;
			set;
		}

		public ConstantForce m_dragForce = new ConstantForce(new UnityEngine.Vector3(0.0f, 0.0f, 0.0f));
		public UnityEngine.Vector3 m_dragDirectionVector = UnityEngine.Vector3.back;
		public float m_drag = 0.0f;

		public float m_density = 1.0f;

		public DragLogic(GameObject parentObj = null)
		{
			m_parentObject = parentObj;
			m_attributes.Add("DragCoefficient", 1.0f);
			m_attributes.Add("ReferenceArea", 1.0f);

			if (m_parentObject is SimplePhysicsLogic)
			{
				p_simplePhysicsLogic = (m_parentObject as SimplePhysicsLogic);
				p_simplePhysicsLogic.addConstanceForce(m_dragForce);
			}
			else
			{
				p_simplePhysicsLogic = null;
			}
		}

		protected override void runPreLogic(float deltaTime)
		{
			if (p_simplePhysicsLogic != null)
			{
				m_drag = (float)m_attributes["DragCoefficient"] * (float)m_attributes["ReferenceArea"] *
						0.5f * m_density * p_simplePhysicsLogic.m_velocity.sqrMagnitude;
				m_dragDirectionVector = -p_simplePhysicsLogic.m_velocity.normalized;
			}
			m_dragForce.force = m_drag * m_dragDirectionVector;
		}

	}
}

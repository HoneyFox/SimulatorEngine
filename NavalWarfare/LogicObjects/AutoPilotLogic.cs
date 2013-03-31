using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimulatorEngine;

namespace NavalWarfare
{
	public class AutoPilotLogic : LogicObject
	{
		public SimplePhysicsLogic p_simplePhysicsLogic
		{
			get;
			set;
		}
		public TurnLogic a_turnLogic
		{
			get;
			set;
		}
		public DragLogic a_aeroDragLogic
		{
			get;
			set;
		}
		public PropulsionLogic a_propulsionLogic
		{
			get;
			set;
		}

		public float m_desiredHeading = 0.0f;
		public float m_desiredPitch = 0.0f;
		public float m_desiredSpeed = 0.0f;

		public float m_currentHeading
		{ 
			get 
			{
				if (a_turnLogic != null)
				{
					if (a_turnLogic.p_simplePhysicsLogic != null)
					{
						return UnityEngine.Mathf.Deg2Rad * a_turnLogic.p_simplePhysicsLogic.m_rotation.eulerAngles.z;
					}
					else
						return float.NaN;
				}
				else
					return float.NaN;
			}
		}

		public float m_currentPitch
		{
			get
			{
				if (a_turnLogic != null)
				{
					if (a_turnLogic.p_simplePhysicsLogic != null)
					{
						return -UnityEngine.Mathf.Deg2Rad * a_turnLogic.p_simplePhysicsLogic.m_rotation.eulerAngles.x;
					}
					else
						return float.NaN;
				}
				else
					return float.NaN;
			}
		}

		public float m_currentSpeed
		{
			get
			{
				if (a_turnLogic != null)
				{
					if (a_turnLogic.p_simplePhysicsLogic != null)
					{
						return a_turnLogic.p_simplePhysicsLogic.m_velocity.magnitude;
					}
					else
						return float.NaN;
				}
				else
					return float.NaN;
			}
		}

		public AutoPilotLogic(GameObject parentObj = null)
		{
			m_parentObject = parentObj;
			if (m_parentObject is SimplePhysicsLogic)
			{
				p_simplePhysicsLogic = (m_parentObject as SimplePhysicsLogic);
				a_turnLogic = p_simplePhysicsLogic.findGameObjectOfType<TurnLogic>();
				a_aeroDragLogic = p_simplePhysicsLogic.findGameObjectOfType<DragLogic>();
				a_propulsionLogic = p_simplePhysicsLogic.findGameObjectOfType<PropulsionLogic>();
			}
		}

		protected override void runPreLogic(float deltaTime)
		{
			if (a_turnLogic != null)
			{
				a_turnLogic.m_desiredYawRate = m_desiredHeading - m_currentHeading;
				a_turnLogic.m_desiredPitchRate = m_desiredPitch - m_currentPitch;
			}
			if (a_propulsionLogic != null)
			{
				a_propulsionLogic.m_throttle += (m_desiredSpeed - m_currentSpeed) * 0.01f;
			}
			if (a_aeroDragLogic != null)
			{
				a_propulsionLogic.m_throttle += a_aeroDragLogic.m_drag / (float)a_propulsionLogic.m_attributes["MaxThrust"];
			}
		}
	}
}

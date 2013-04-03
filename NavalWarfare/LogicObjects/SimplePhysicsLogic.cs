using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimulatorEngine;

namespace NavalWarfare
{
	public class SimplePhysicsLogic : LogicObject
	{
		public UnityEngine.Vector3 m_position = new UnityEngine.Vector3(0.0f, 0.0f, 0.0f);
		public UnityEngine.Vector3 m_velocity = new UnityEngine.Vector3(0.0f, 0.0f, 0.0f);
		public UnityEngine.Quaternion m_rotation
		{
			get
			{
				return UnityEngine.Quaternion.LookRotation(m_velocity.normalized);
			}
		}
		
		List<ConstantForce> m_constantForces = new List<ConstantForce>();
		List<UnityEngine.Vector3> m_impulseForces = new List<UnityEngine.Vector3>();

		public void addConstanceForce(ConstantForce force)
		{
			m_constantForces.Add(force);
		}
		public void addImpulseForce(UnityEngine.Vector3 force)
		{
			m_impulseForces.Add(force);
		}

		public float m_mass;
        public float m_ReflectionArea;
		protected override void runPreLogic(float deltaTime)
		{
			m_impulseForces.Clear();
		}

		protected override void runPostLogic(float deltaTime)
		{
			UnityEngine.Vector3 totalForce = new UnityEngine.Vector3(0.0f, 0.0f, 0.0f);

			foreach (ConstantForce constantForce in m_constantForces)
				totalForce += constantForce.force;
			foreach (UnityEngine.Vector3 force in m_impulseForces)
				totalForce += force;

			m_position += m_velocity * deltaTime;
			m_velocity += totalForce / m_mass * deltaTime;
			
		}
	}
}

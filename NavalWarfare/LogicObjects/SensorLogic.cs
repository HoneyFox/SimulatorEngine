using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimulatorEngine;

namespace NavalWarfare
{
	public class SensorLogic : LogicObject, IToggleable
	{
		public TargetControlLogic p_targetControlLogic
		{
			get;
			set;
		}

		public List<SensorContactLogic> m_contacts = new List<SensorContactLogic>();

		private bool m_active = true;

		public SensorLogic(GameObject parentObj = null)
		{
			m_parentObject = parentObj;
			if (m_parentObject is TargetControlLogic)
			{
				p_targetControlLogic = (m_parentObject as TargetControlLogic);
			}
		}

		protected override void runPreLogic(float deltaTime)
		{
			LogicObject sceneRoot = NavalWarfare.GetInstance().findRootGameObjectOfType<LogicObject>();
			m_contacts.Clear();
			if (m_active)
			{
				foreach (GameObject gameObj in sceneRoot.m_gameObjects)
				{
					if (gameObj is SceneObject)
					{
						m_contacts.Add(new SensorContactLogic(this, (gameObj as SceneObject)));
					}
				}
			}
		}

		public bool Active
		{
			get
			{
				return m_active;
			}
			set
			{
				m_active = value;
			}
		}
	}
}

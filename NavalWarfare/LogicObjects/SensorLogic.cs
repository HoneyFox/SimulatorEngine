using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimulatorEngine;

namespace NavalWarfare
{
	public class SensorLogic : LogicObject
	{
		public TargetControlLogic p_targetControlLogic
		{
			get;
			set;
		}

		public List<SensorContactLogic> m_contacts = new List<SensorContactLogic>();
		
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
			foreach(GameObject gameObj in sceneRoot.m_gameObjects)
			{
				if (gameObj is TypeObject)
				{
					m_contacts.Add(new SensorContactLogic(this, (gameObj as SceneObject)));
				}
			}
		} 
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimulatorEngine;

namespace NavalWarfare
{
	public class SensorContactLogic : LogicObject
	{
		public SensorLogic p_sensorLogic = null;
		public SceneObject mTarget = null;

		public SensorContactLogic(GameObject parentObj = null, SceneObject targetObj = null)
		{
			m_parentObject = parentObj;
			if (m_parentObject is SensorLogic)
			{
				p_sensorLogic = (m_parentObject as SensorLogic);
				mTarget = (targetObj as SceneObject);
			}
		}
	}
}

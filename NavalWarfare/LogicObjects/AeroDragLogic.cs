using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimulatorEngine;

namespace NavalWarfare
{
	public class AeroDragLogic : DragLogic
	{
		public float m_density = 1.29f;

		public AeroDragLogic(GameObject parentObj = null)
		{
			m_parentObject = parentObj;
			m_attributes["DragCoefficient"] = 0.25f;
			m_attributes["ReferenceArea"] = 0.75f;
		}
	}
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimulatorEngine;

namespace NavalWarfare
{
	public class WaterDragLogic : DragLogic
	{
		public WaterDragLogic(GameObject parentObj = null)
		{
			m_parentObject = parentObj;
			m_density = 986.0f;
			m_attributes["DragCoefficient"] = 0.22f;
			m_attributes["ReferenceArea"] = 150.75f;
		}
	}
}

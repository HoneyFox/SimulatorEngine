using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimulatorEngine;

namespace NavalWarfare
{
	public class ConstantForce : LogicObject
	{
		public UnityEngine.Vector3 force = new UnityEngine.Vector3(0.0f, 0.0f, 0.0f);

		public ConstantForce(UnityEngine.Vector3 force)
		{
			this.force = force;
		}
	}
}

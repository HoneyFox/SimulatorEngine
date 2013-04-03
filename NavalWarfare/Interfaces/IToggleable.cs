using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimulatorEngine;

namespace NavalWarfare
{
	interface IToggleable
	{
		bool Active
		{
			get;
			set;
		}
	}
}

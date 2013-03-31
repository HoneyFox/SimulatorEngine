using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using SimulatorEngine;

namespace NavalWarfare
{
	public class NavalWarfare : GameEngine
	{
		public static NavalWarfare Singleton = null;
		public static void CreateInstance()
		{
			Singleton = new NavalWarfare();
		}
		public static NavalWarfare GetInstance()
		{
			return Singleton;
		}

		public Graphics m_graphics
		{
			private get;
			set;
		}

		public override void initialize()
		{
			
		}
	}
}

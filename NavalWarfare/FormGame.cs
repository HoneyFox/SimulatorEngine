using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimulatorEngine;

namespace NavalWarfare
{
	public partial class FormGame : Form
	{
		GameEngine m_gameEngine;

		public FormGame()
		{
			InitializeComponent();
		}

		public void setGameEngine(GameEngine engine)
		{
			m_gameEngine = engine;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NavalWarfare
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			FormGame frmGame = new FormGame();
			NavalWarfare gameEngine = new NavalWarfare();
			frmGame.setGameEngine(gameEngine);
			gameEngine.m_graphics = frmGame.CreateGraphics();

			Application.Run(frmGame);
		}
	}
}
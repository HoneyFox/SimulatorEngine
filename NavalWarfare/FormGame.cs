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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ESMLogic lll=new ESMLogic();
            ESMLogic lll1=(ESMLogic)lll.Clone();
        }
	}
}

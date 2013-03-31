using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulatorEngine
{
    public class GameEngine
    {
        // All root game objects will be inside this.
        public List<GameObject> m_rootGameObjects = new List<GameObject>();
        DateTime m_time = DateTime.Now;

        public virtual void initialize()
        { 
            
        }

        public void mainLoop()
        {
            while (true)
            {
                update();
                render();
            }
        }

        private void update()
        {
            float deltaTime = (float)(DateTime.Now.Subtract(m_time).TotalSeconds);
            m_time = DateTime.Now;
            foreach (GameObject gameObj in m_rootGameObjects)
            {
                gameObj.update(deltaTime);
            }
        }

        private void render()
        {
            foreach (GameObject gameObj in m_rootGameObjects)
            {
                gameObj.render();
            }
        }

		public T findRootGameObjectOfType<T>() where T : class
		{
			foreach (GameObject gameObj in m_rootGameObjects)
			{
				if (gameObj is T)
					return (gameObj as T);
			}
			return null;
		}

    }
}

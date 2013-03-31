using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulatorEngine
{
	public class GameObject
    {
		public GameObject(GameObject parentObj = null)
		{
			m_parentObject = parentObj;
		}

		public GameObject m_parentObject = null;

        public List<GameObject> m_gameObjects = new List<GameObject>();
        public Queue<EventMessage> m_messageQueue = new Queue<EventMessage>();

        public Dictionary<string, Object> m_attributes = new Dictionary<string,object>();

		public T findGameObjectOfType<T>() where T : class
		{
			foreach (GameObject gameObj in m_gameObjects)
			{
				if (gameObj is T)
					return (gameObj as T);
			}
			return null;
		}

        public void update(float deltaTime)
        {
            this.preChildrenUpdate(deltaTime);
            foreach (GameObject gameObj in m_gameObjects)
            {
                gameObj.update(deltaTime);
            }
            this.postChildrenUpdate(deltaTime);

            while (m_messageQueue.Count > 0)
            {
                m_messageQueue.Dequeue().processMessage();
            }
        }

        public virtual void render()
        {
            foreach (GameObject gameObj in m_gameObjects)
            {
                gameObj.render();
            }
        }

        protected virtual void preChildrenUpdate(float deltaTime)
        { 
            
        }

        protected virtual void postChildrenUpdate(float deltaTime)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulatorEngine
{
	public class EventMessage
    {
        public GameObject sender
        {
            get;
            private set;
        }
        public Object message
        {
            get;
            set;
        }
        public Action<Object> action
        {
            get;
            set;
        }

        public void processMessage()
        {
            if (this.action != null)
                this.action(message);
        }

        public static EventMessage createEventMessage(GameObject sender = null, Object message = null, Action<Object> action = null)
        {
            EventMessage em = new EventMessage();
            em.sender = sender;
            em.message = message;
            em.action = action;
            return em;
        }

        public static void sendEventMessage(EventMessage eventMessage, GameObject receiver)
        {
            receiver.m_messageQueue.Enqueue(eventMessage);
        }

        public static void sendEventMessage(EventMessage eventMessage, List<GameObject> receivers)
        {
            foreach (GameObject gameObj in receivers)
                sendEventMessage(eventMessage, gameObj);
        }

        public static void sendQueryMessage(EventMessage eventMessage, GameObject receiver, Func<Object, Object> queryFunc)
        {
            eventMessage.action = (Object obj) =>
            {
                Object result = queryFunc(obj);
                EventMessage reply = createEventMessage(receiver, result);
                sendEventMessage(reply, eventMessage.sender);
            };
            receiver.m_messageQueue.Enqueue(eventMessage);
        }

        public static void sendQueryMessage(EventMessage eventMessage, List<GameObject> receivers, Func<Object, Object> queryFunc)
        {
            foreach (GameObject gameObj in receivers)
                sendQueryMessage(eventMessage, gameObj, queryFunc);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;

namespace SimulatorEngine
{
	public class GameObject : ICloneable
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
        /// <summary>    
        /// Clone the object and return the refrence of cloned object   
        /// </summary>    
        /// <returns>the refrence of cloned object</returns> 
        /// 
        public object Clone()
        {
            //首先我们建立指定类型的一个实例         
            object newObject = Activator.CreateInstance(this.GetType());
            //我们取得新的类型实例的字段数组。         
            FieldInfo[] fields = newObject.GetType().GetFields();
            int i = 0;
            foreach (FieldInfo fi in this.GetType().GetFields())
            {
                //我们判断字段是否支持ICloneable接口。             
                Type ICloneType = fi.FieldType.GetInterface("ICloneable", true);
                if (ICloneType != null)
                {
                    //取得对象的Icloneable接口。                 
                    ICloneable IClone = (ICloneable)fi.GetValue(this);
                    //我们使用克隆方法给字段设定新值。                
                    fields[i].SetValue(newObject, IClone.Clone());
                }
                else
                {
                    // 如果该字段部支持Icloneable接口，直接设置即可。                 
                    fields[i].SetValue(newObject, fi.GetValue(this));
                }
                //现在我们检查该对象是否支持IEnumerable接口，如果支持，             
                //我们还需要枚举其所有项并检查他们是否支持IList 或 IDictionary 接口。            
                Type IEnumerableType = fi.FieldType.GetInterface("IEnumerable", true);
                if (IEnumerableType != null)
                {
                    //取得该字段的IEnumerable接口                
                    IEnumerable IEnum = (IEnumerable)fi.GetValue(this);
                    Type IListType = fields[i].FieldType.GetInterface("IList", true);
                    Type IDicType = fields[i].FieldType.GetInterface("IDictionary", true);
                    int j = 0;
                    if (IListType != null)
                    {
                        //取得IList接口。                     
                        IList list = (IList)fields[i].GetValue(newObject);
                        foreach (object obj in IEnum)
                        {
                            //查看当前项是否支持支持ICloneable 接口。                         
                            ICloneType = obj.GetType().GetInterface("ICloneable", true);
                            if (ICloneType != null)
                            {
                                //如果支持ICloneable 接口，			 
                                //我们用它李设置列表中的对象的克隆			 
                                ICloneable clone = (ICloneable)obj;
                                list[j] = clone.Clone();
                            }
                            //注意：如果列表中的项不支持ICloneable接口，那么                      
                            //在克隆列表的项将与原列表对应项相同                      
                            //（只要该类型是引用类型）                        
                            j++;
                        }
                    }
                    else if (IDicType != null)
                    {
                        //取得IDictionary 接口                    
                        IDictionary dic = (IDictionary)fields[i].GetValue(newObject);
                        j = 0;
                        foreach (DictionaryEntry de in IEnum)
                        {
                            //查看当前项是否支持支持ICloneable 接口。                         
                            ICloneType = de.Value.GetType().
                                GetInterface("ICloneable", true);
                            if (ICloneType != null)
                            {
                                ICloneable clone = (ICloneable)de.Value;
                                dic[de.Key] = clone.Clone();
                            }
                            j++;
                        }
                    }
                }
                i++;
            }
            return newObject;
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

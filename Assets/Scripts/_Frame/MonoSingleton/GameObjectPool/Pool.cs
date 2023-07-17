using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace GameObjectPool
{
    /// <summary>
    /// 对象池
    /// </summary>
    public class Pool
    {
        private Queue<GameObject> objectPool;

        public Pool()
        {
            objectPool = new Queue<GameObject>();
        }

        public GameObject GetUsableObject(GameObject prefab)
        {
            GameObject target = objectPool.Count > 0 ? objectPool.Dequeue() : CopyObjct(prefab);
            return target;
        }

        private GameObject CopyObjct(GameObject prefab)
        {
            GameObject copyObject = GameObject.Instantiate<GameObject>(prefab);
            return copyObject;
        }

        public void Recycle(GameObject recycleObject)
        {
#if UNITY_EDITOR
            if (recycleObject == null) Debug.Log("回收对象为空！！！");
#endif
            recycleObject.SetActive(false);
            objectPool.Enqueue(recycleObject);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameObjectPool
{
    /// <summary>
    /// 对象池管理类
    /// </summary>
    public class GameObjectPool : MonoSingleton<GameObjectPool>
    {
        private Dictionary<GameObject, Pool> objectPoolMap;

        private WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

        protected override void Awake()
        {
            base.Awake();
            objectPoolMap = new Dictionary<GameObject, Pool>();
        }

        public GameObject Get(GameObject prefab, Vector3 position, Func<bool> recycleCondition)
        {
            return Get(prefab, position, prefab.transform.rotation, recycleCondition);
        }

        public GameObject Get(GameObject prefab, Vector3 position, Quaternion rotation, Func<bool> recycleCondition)
        {
            Pool objectPool = objectPoolMap.ContainsKey(prefab) ? objectPoolMap[prefab] : AddObjectPool(prefab);
            GameObject target = objectPool.GetUsableObject(prefab);
            target.transform.SetParent(transform);
            target.transform.SetPositionAndRotation(position, rotation);
            target.SetActive(true);
            StartCoroutine(RecycleCoroutine(prefab, target, recycleCondition));
            return target;
        }

        private Pool AddObjectPool(GameObject key)
        {
            Pool objectPool = new Pool();
            objectPoolMap.Add(key, objectPool);
            return objectPool;
        }

        private IEnumerator RecycleCoroutine(GameObject prefab, GameObject recycleObject, Func<bool> recycleCondition)
        {
            while (!recycleCondition())
            {
                yield return waitForFixedUpdate;
            };
            Recycle(prefab, recycleObject);
        }


        private void Recycle(GameObject key, GameObject recycleObject)
        {
            Pool objectPool = objectPoolMap[key];
            objectPool.Recycle(recycleObject);
        }
    }
}

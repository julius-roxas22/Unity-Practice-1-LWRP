using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    public class PoolObjectManager : Singleton<PoolObjectManager>
    {
        public Dictionary<PoolObjectType, List<GameObject>> poolDictionary = new Dictionary<PoolObjectType, List<GameObject>>();

        public void setUpDictionary()
        {
            PoolObjectType[] poolArr = System.Enum.GetValues(typeof(PoolObjectType)) as PoolObjectType[];

            foreach (PoolObjectType p in poolArr)
            {
                if (!poolDictionary.ContainsKey(p))
                {
                    poolDictionary.Add(p, new List<GameObject>());
                }
            }
        }

        public GameObject getPoolObject(PoolObjectType objectType)
        {
            if (poolDictionary.Count == 0)
            {
                setUpDictionary();
            }

            List<GameObject> objList = poolDictionary[objectType];
            GameObject obj = null;

            if(objList.Count > 0)
            {
                obj = objList[0];
                objList.RemoveAt(0);
            }
            else
            {
                obj = PoolObjectLoader.instantiatePoolObjectLoader(objectType).gameObject;
            }

            return obj;
        }

        public void addPoolObject(PoolObject poolObject)
        {
            List<GameObject> objList = poolDictionary[poolObject.objectType];
            objList.Add(poolObject.gameObject);
            poolObject.gameObject.SetActive(false);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    public enum PoolObjectType
    {
        AttackInfo
    }

    public class PoolObjectLoader : MonoBehaviour
    {
        public static PoolObject instantiatePoolObjectLoader(PoolObjectType objectType)
        {
            GameObject obj = null;

            switch (objectType)
            {
                case PoolObjectType.AttackInfo:
                    {
                        obj = Instantiate(Resources.Load("AttackInfo" , typeof(GameObject))) as GameObject;
                        break;
                    }
            }
            return obj.GetComponent<PoolObject>();
        }
    }
}

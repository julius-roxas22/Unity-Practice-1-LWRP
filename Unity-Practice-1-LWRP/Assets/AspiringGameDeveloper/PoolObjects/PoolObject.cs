using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    public class PoolObject : MonoBehaviour
    {
        public PoolObjectType objectType;

        public float scheduleTimeOff;
        private Coroutine offRoutine;

        private void OnEnable()
        {
            if (null != offRoutine)
            {
                StopCoroutine(offRoutine);
            }

            if (scheduleTimeOff > 0f)
            {
                offRoutine = StartCoroutine(scheduleOff());
            }
        }

        public void turnOff()
        {
            PoolObjectManager.getInstance.addPoolObject(this);
        }

        IEnumerator scheduleOff()
        {
            yield return new WaitForSeconds(scheduleTimeOff);

            if (!PoolObjectManager.getInstance.poolDictionary[objectType].Contains(gameObject))
            {
                turnOff();
            }
        }
    }
}
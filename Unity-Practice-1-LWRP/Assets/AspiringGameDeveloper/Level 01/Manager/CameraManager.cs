using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    public class CameraManager : Singleton<CameraManager>
    {
        private CameraController cameraController;
        private Coroutine routine;

        public Camera mainCamera;

        private CameraController getCameraController()
        {
            if(null == cameraController)
            {
                cameraController = FindObjectOfType<CameraController>();
            }
            return cameraController;
        }

        private void Awake()
        {
            mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        }

        IEnumerator cameraStateTiming()
        {
            getCameraController().cameraTrigger(CameraState.Shake);
            yield return new WaitForSeconds(getCameraController().shakeDuration);
            getCameraController().cameraTrigger(CameraState.Default);
        }

        public void cameraShake()
        {
            if(null != routine)
            {
                StopCoroutine(routine);
            }

            routine = StartCoroutine(cameraStateTiming());
        }
    }

}
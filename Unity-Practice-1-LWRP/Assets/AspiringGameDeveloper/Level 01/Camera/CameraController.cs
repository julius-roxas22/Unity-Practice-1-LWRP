using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    public enum CameraState
    {
        Shake,
        Default
    }
    public class CameraController : MonoBehaviour
    {
        public float shakeDuration;
        private Animator animator;

        public Animator getCameraAnimator()
        {
            if (null == animator)
            {
                animator = GetComponent<Animator>();
            }

            return animator;
        }

        public void cameraTrigger(CameraState cameraState)
        {
            getCameraAnimator().SetTrigger(cameraState.ToString());
        }

    }
}
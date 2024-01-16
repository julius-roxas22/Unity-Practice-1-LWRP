using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    public class CameraStateBehaviour : StateMachineBehaviour
    {
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            CameraState[] camStates = System.Enum.GetValues(typeof(CameraState)) as CameraState[];

            foreach(CameraState cam in camStates)
            {
                animator.ResetTrigger(cam.ToString());
            }
        }

    }
}



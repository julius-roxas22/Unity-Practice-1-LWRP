using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    [CreateAssetMenu(fileName = "New Ability", menuName = "AspiringGameDev/Ability/ShakeCamera")]
    public class ShakeCamera : ScriptableBase
    {
        [Range(0, 99f)]
        public float shakeTiming;

        private bool isShaken;

        public override void onStateEnter(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (shakeTiming == 0)
            {
                CameraManager.getInstance.cameraShake();
                isShaken = true;
            }
        }

        public override void onStateUpdate(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (!isShaken && stateInfo.normalizedTime >= shakeTiming)
            {
                CameraManager.getInstance.cameraShake();
                isShaken = true;
            }
        }

        public override void onStateExit(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {
            isShaken = false;
        }
    }
}


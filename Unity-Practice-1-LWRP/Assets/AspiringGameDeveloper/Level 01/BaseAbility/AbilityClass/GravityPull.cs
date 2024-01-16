using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    [CreateAssetMenu(fileName = "New Ability", menuName = "AspiringGameDev/Ability/GravityMultiplier")]
    public class GravityPull : ScriptableBase
    {
        public AnimationCurve pullGravity;

        public override void onStateEnter(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

        public override void onStateUpdate(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {
            control.pullGravity = pullGravity.Evaluate(stateInfo.normalizedTime);
        }

        public override void onStateExit(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {
            control.pullGravity = 0f;
        }
    }
}


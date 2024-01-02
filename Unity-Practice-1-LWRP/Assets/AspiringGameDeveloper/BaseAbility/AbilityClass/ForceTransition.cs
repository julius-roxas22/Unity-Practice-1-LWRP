using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    [CreateAssetMenu(fileName = "New Ability", menuName = "AspiringGameDev/Ability/ForceTransition")]
    public class ForceTransition : ScriptableBase
    {
        [Range(0.01f, 1f)]
        public float transitionTiming;
        public override void onStateEnter(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void onStateUpdate(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime >= transitionTiming)
            {
                animator.SetBool(TransitionParameter.ForceTransition.ToString(), true);
            }
        }

        public override void onStateExit(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.ForceTransition.ToString(), false);
        }
    }
}


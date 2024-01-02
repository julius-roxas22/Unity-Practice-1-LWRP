using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    [CreateAssetMenu(fileName = "New Ability", menuName = "AspiringGameDev/Ability/Jump")]
    public class Jump : ScriptableBase
    {
        public float jumpForce;
        public AnimationCurve gravityMultiplier;
        public AnimationCurve pullGravity;

        public override void onStateEnter(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {
            control.getRigidbody.AddForce(Vector3.up * jumpForce);
            animator.SetBool(TransitionParameter.Grounded.ToString(), false);
        }

        public override void onStateUpdate(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {
            control.gravityMultiplier = gravityMultiplier.Evaluate(stateInfo.normalizedTime);
            control.pullGravity = pullGravity.Evaluate(stateInfo.normalizedTime);
        }

        public override void onStateExit(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}


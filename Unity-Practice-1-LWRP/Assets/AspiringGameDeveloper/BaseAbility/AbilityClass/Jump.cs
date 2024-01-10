using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    [CreateAssetMenu(fileName = "New Ability", menuName = "AspiringGameDev/Ability/Jump")]
    public class Jump : ScriptableBase
    {
        [Range(0f, 1f)]
        public float jumpTiming;
        public float jumpForce;
        //public AnimationCurve gravityMultiplier;
        public AnimationCurve pullGravity;

        private bool isJumped;

        public override void onStateEnter(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (jumpTiming == 0f)
            {
                control.getRigidbody.AddForce(Vector3.up * jumpForce);
                isJumped = true;
            }
            animator.SetBool(TransitionParameter.Grounded.ToString(), false);
        }

        public override void onStateUpdate(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {
            //control.gravityMultiplier = gravityMultiplier.Evaluate(stateInfo.normalizedTime);
            control.pullGravity = pullGravity.Evaluate(stateInfo.normalizedTime);

            if (!isJumped && stateInfo.normalizedTime >= jumpTiming)
            {
                control.getRigidbody.AddForce(Vector3.up * jumpForce);
                isJumped = true;
            }

        }

        public override void onStateExit(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {
            control.pullGravity = 0f;
            isJumped = false;
        }
    }
}


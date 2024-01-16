using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    [CreateAssetMenu(fileName = "New Ability", menuName = "AspiringGameDev/Ability/GroundDetector")]
    public class GroundDetector : ScriptableBase
    {
        [Range(0.01f, 1f)]
        public float checkTime;

        public float groundDistance;
        public override void onStateEnter(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void onStateUpdate(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime >= checkTime)
            {
                if (isGrounded(control))
                {
                    animator.SetBool(TransitionParameter.Grounded.ToString(), true);
                }
                else
                {
                    animator.SetBool(TransitionParameter.Grounded.ToString(), false);
                }
            }
        }

        public override void onStateExit(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        bool isGrounded(CharacterControl control)
        {
            if (control.getRigidbody.velocity.y > -0.001f && control.getRigidbody.velocity.y <= 0f) return true;

            if (control.getRigidbody.velocity.y < 0f)
            {
                foreach (GameObject o in control.bottomSpheres)
                {
                    Debug.DrawRay(o.transform.position, Vector3.down * groundDistance, Color.yellow);
                    RaycastHit hit;
                    if (Physics.Raycast(o.transform.position, Vector3.down, out hit, groundDistance))
                    {
                        if (!control.ragdollParts.Contains(hit.collider)) return true;
                    }
                }
            }
            return false;
        }
    }
}


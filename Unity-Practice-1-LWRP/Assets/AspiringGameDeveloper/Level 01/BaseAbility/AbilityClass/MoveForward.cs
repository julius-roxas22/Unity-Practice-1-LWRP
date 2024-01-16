using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    [CreateAssetMenu(fileName = "New Ability", menuName = "AspiringGameDev/Ability/MoveForward")]
    public class MoveForward : ScriptableBase
    {
        public bool constantMove;
        public float speedForward;
        public float blockDistance;
        public AnimationCurve speedGraph;
        public override void onStateEnter(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void onStateUpdate(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (control.moveRight && control.moveLeft)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }

            if (!control.moveRight && !control.moveLeft)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
            }

            if (constantMove)
            {
                unControlledMove(control, stateInfo);
            }
            else
            {
                controlledMove(control, stateInfo, animator);
            }
        }

        public override void onStateExit(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        bool checkFront(CharacterControl control)
        {
            foreach (GameObject o in control.frontSpheres)
            {
                RaycastHit hit;
                Debug.DrawRay(o.transform.position, control.transform.forward * blockDistance, Color.yellow);
                if (Physics.Raycast(o.transform.position, control.transform.forward, out hit, blockDistance))
                {
                    if (!control.ragdollParts.Contains(hit.collider))
                    {
                        if (!isBodyPart(hit.collider)) return true;
                    }
                }
            }
            return false;
        }

        bool isBodyPart(Collider col)
        {
            CharacterControl control = col.transform.root.GetComponent<CharacterControl>();
            if (null == control) return false;

            if (control.gameObject == col.gameObject) return false;

            if (control.ragdollParts.Contains(col)) return true;

            return false;
        }

        public void unControlledMove(CharacterControl control, AnimatorStateInfo stateInfo)
        {
            if (!checkFront(control)) control.characterMove(speedGraph.Evaluate(stateInfo.normalizedTime), speedForward);
        }

        public void controlledMove(CharacterControl control, AnimatorStateInfo stateInfo, Animator animator)
        {
            if (control.moveRight)
            {
                if (!checkFront(control)) control.characterMove(speedGraph.Evaluate(stateInfo.normalizedTime), speedForward);
                control.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }

            if (control.moveLeft)
            {
                if (!checkFront(control)) control.characterMove(speedGraph.Evaluate(stateInfo.normalizedTime), speedForward);
                control.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }

            if (control.jump)
            {
                animator.SetBool(TransitionParameter.Jump.ToString(), true);
            }
        }
    }
}

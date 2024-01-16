using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    [CreateAssetMenu(fileName = "New Ability", menuName = "AspiringGameDev/Ability/CheckAttack")]
    public class CheckAttack : ScriptableBase
    {

        public override void onStateEnter(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void onStateUpdate(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (control.attack)
            {
                animator.SetBool(TransitionParameter.Attack.ToString() , true);
            }
        }

        public override void onStateExit(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}
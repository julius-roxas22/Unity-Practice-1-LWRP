using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    public class StateBase : StateMachineBehaviour
    {
        private CharacterControl control;
        public List<ScriptableBase> abilityData = new List<ScriptableBase>();

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach(ScriptableBase data in abilityData)
            {
                data.onStateEnter(getCharacterControl(animator) , animator , stateInfo);
            }
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (ScriptableBase data in abilityData)
            {
                data.onStateUpdate(getCharacterControl(animator), animator , stateInfo);
            }
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (ScriptableBase data in abilityData)
            {
                data.onStateExit(getCharacterControl(animator), animator, stateInfo);
            }
        }

        public CharacterControl getCharacterControl(Animator animator)
        {
            if (null == control) control = animator.GetComponentInParent<CharacterControl>();
            return control;
        }
    }
}
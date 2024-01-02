using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    public abstract class ScriptableBase : ScriptableObject
    {
        public abstract void onStateEnter(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo);
        public abstract void onStateUpdate(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo);
        public abstract void onStateExit(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    public class ManualInput : MonoBehaviour
    {
        CharacterControl control;
        private void Awake()
        {
            control = GetComponent<CharacterControl>();
        }

        void Update()
        {
            control.moveRight = VirtualInputManager.getInstance.moveRight;
            control.moveLeft = VirtualInputManager.getInstance.moveLeft;
            control.jump = VirtualInputManager.getInstance.jump;
            control.attack = VirtualInputManager.getInstance.attack;
        }
    }
}

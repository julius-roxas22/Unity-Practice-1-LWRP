using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    public class KeyboardInput : MonoBehaviour
    {
        void Update()
        {
            VirtualInputManager.getInstance.moveRight = Input.GetKey(KeyCode.D) ? true : false;
            VirtualInputManager.getInstance.moveLeft= Input.GetKey(KeyCode.A) ? true : false;
            VirtualInputManager.getInstance.jump = Input.GetKey(KeyCode.Space) ? true : false;
            VirtualInputManager.getInstance.attack = Input.GetKey(KeyCode.Return) ? true : false;
        }
    }
}
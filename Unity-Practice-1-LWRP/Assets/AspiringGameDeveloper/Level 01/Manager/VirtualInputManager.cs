using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    public class VirtualInputManager : Singleton<VirtualInputManager>
    {
        public bool moveRight;
        public bool moveLeft;
        public bool jump;
        public bool attack;
    }
}
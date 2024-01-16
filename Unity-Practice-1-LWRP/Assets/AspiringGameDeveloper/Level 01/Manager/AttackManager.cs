using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    public class AttackManager : Singleton<AttackManager>
    {
        public List<AttackInfo> currentAttacks = new List<AttackInfo>();
    }
}


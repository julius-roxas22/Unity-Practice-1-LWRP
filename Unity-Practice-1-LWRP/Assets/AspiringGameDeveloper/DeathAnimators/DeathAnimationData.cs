using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    [CreateAssetMenu(fileName = "New Death Data" , menuName = "AspiringGameDev/Death/DeathAnimationData")]
    public class DeathAnimationData : ScriptableObject
    {
        public List<BodyParts> bodyParts = new List<BodyParts>();
        public RuntimeAnimatorController deathController;
        public bool isFacingAttack;
    }
}
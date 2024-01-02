using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    public class AttackInfo : MonoBehaviour
    {
        public List<string> colliderNames = new List<string>();

        public CharacterControl attacker = null;
        public Attack attackAbility;

        public bool isCollide;
        public bool faceTheAttacker;
        public bool isRegisterd;
        public bool isFinished;

        public float range;

        public int maxHits;
        public int currentHits;

        public void resetInfo(Attack attackAbility, CharacterControl attacker)
        {
            isRegisterd = false;
            isFinished = false;
            this.attackAbility = attackAbility;
            this.attacker = attacker;
        }

        public void registerAttack(Attack attackAbility)
        {
            isRegisterd = true;

            this.attackAbility = attackAbility;
            colliderNames = attackAbility.colliderNames;
            isCollide = attackAbility.isCollide;
            faceTheAttacker = attackAbility.faceTheAttacker;
            range = attackAbility.range;
            maxHits = attackAbility.maxHits;
            currentHits = 0;
        }

        private void OnDisable()
        {
            isFinished = true;
        }
    }
}


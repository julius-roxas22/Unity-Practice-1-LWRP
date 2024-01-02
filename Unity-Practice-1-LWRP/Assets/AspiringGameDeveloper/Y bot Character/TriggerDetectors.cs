using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    public enum BodyParts
    {
        Upper,
        Lower,
        Arm,
        Leg
    }

    public class TriggerDetectors : MonoBehaviour
    {
        public BodyParts bodyParts;
        public List<Collider> collidingParts = new List<Collider>();

        private CharacterControl owner;
        
        private void Awake()
        {
            owner = GetComponentInParent<CharacterControl>();
        }

        private void OnTriggerEnter(Collider col)
        {
            if (owner.ragdollParts.Contains(col)) return;

            CharacterControl attacker = col.transform.root.GetComponent<CharacterControl>();

            if (null == attacker) return;

            if (col.gameObject == attacker.gameObject) return;

            if (!collidingParts.Contains(col)) collidingParts.Add(col);
        }

        private void OnTriggerExit(Collider attacker)
        {
            if (collidingParts.Contains(attacker)) collidingParts.Remove(attacker);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    public class DamageDetector : MonoBehaviour
    {
        private CharacterControl control;

        private BodyParts bodyParts;
        private void Awake()
        {
            control = GetComponent<CharacterControl>();
        }
        void Update()
        {
            if (AttackManager.getInstance.currentAttacks.Count > 0)
            {
                checkAttack();
            }
        }

        void checkAttack()
        {
            foreach (AttackInfo info in AttackManager.getInstance.currentAttacks)
            {
                if (null == info) continue;

                if (!info.isRegisterd) continue;

                if (info.isFinished) continue;

                if (info.attacker == control) continue;

                if (info.currentHits >= info.maxHits) continue;

                if (info.isCollide)
                {
                    if (isCollided(info))
                    {
                        takeDamage(info);
                    }
                }
            }
        }

        bool isCollided(AttackInfo info)
        {
            foreach (TriggerDetectors triggers in control.getAllTriggerDetector())
            {
                foreach (Collider col in triggers.collidingParts)
                {
                    foreach (string collideNames in info.colliderNames)
                    {
                        bodyParts = triggers.bodyParts;
                        if (collideNames.Equals(col.gameObject.name)) return true;
                    }
                }
            }
            return false;
        }

        private void takeDamage(AttackInfo info)
        {
            CameraManager.getInstance.cameraShake();
            control.GetComponent<BoxCollider>().enabled = false;
            control.getRigidbody.velocity = Vector3.zero;
            control.getRigidbody.useGravity = false;
            control.skinnedMesh.runtimeAnimatorController = DeathAnimationManager.getInstance.getDeathAnimator(bodyParts, info);
            info.currentHits++;
        }
    }
}


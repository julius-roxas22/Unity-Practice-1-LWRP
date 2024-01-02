using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    [CreateAssetMenu(fileName = "New Ability", menuName = "AspiringGameDev/Ability/Attack")]
    public class Attack : ScriptableBase
    {
        public float startAttackTime;
        public float endAttackTime;
        public List<string> colliderNames = new List<string>();

        public bool isCollide;
        public bool faceTheAttacker;
        public float range;
        public int maxHits;

        private List<AttackInfo> finishedAttacks = new List<AttackInfo>();

        public override void onStateEnter(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.Attack.ToString(), false);

            GameObject obj = PoolObjectManager.getInstance.getPoolObject(PoolObjectType.AttackInfo);
            AttackInfo info = obj.GetComponent<AttackInfo>();

            obj.SetActive(true);
            info.resetInfo(this, control);

            if (!AttackManager.getInstance.currentAttacks.Contains(info)) AttackManager.getInstance.currentAttacks.Add(info);
        }

        public override void onStateUpdate(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {
            registerAttack(stateInfo);
            deRegisterAttack(stateInfo);
        }

        void registerAttack(AnimatorStateInfo stateInfo)
        {
            if (startAttackTime <= stateInfo.normalizedTime && endAttackTime > stateInfo.normalizedTime)
            {
                foreach (AttackInfo info in AttackManager.getInstance.currentAttacks)
                {
                    if (null == info) continue;

                    if (info.attackAbility == this && !info.isRegisterd)
                    {
                        info.registerAttack(this);
                    }
                }
            }
        }

        void deRegisterAttack(AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime >= endAttackTime)
            {
                foreach (AttackInfo info in AttackManager.getInstance.currentAttacks)
                {
                    if (null == info) continue;

                    if (info.attackAbility == this && !info.isFinished)
                    {
                        info.isFinished = true;
                        info.GetComponent<PoolObject>().turnOff();
                    }
                }
            }
        }

        public override void onStateExit(CharacterControl control, Animator animator, AnimatorStateInfo stateInfo)
        {
            clearAttack();
        }

        private void clearAttack()
        {
            finishedAttacks.Clear();

            foreach (AttackInfo info in AttackManager.getInstance.currentAttacks)
            {
                if (null == info || info.isFinished)
                {
                    finishedAttacks.Add(info);
                }
            }

            foreach (AttackInfo info in finishedAttacks)
            {
                if (AttackManager.getInstance.currentAttacks.Contains(info))
                {
                    AttackManager.getInstance.currentAttacks.Remove(info);
                }
            }
        }

    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    public class DeathAnimationManager : Singleton<DeathAnimationManager>
    {
        private DeathAnimationLoader deathAnimationLoader;

        private List<RuntimeAnimatorController> candidates = new List<RuntimeAnimatorController>();

        private void setUpDeathAnimationLoader()
        {
            if (null == deathAnimationLoader)
            {
                GameObject obj = Instantiate(Resources.Load("DeathAnimationLoader", typeof(GameObject))) as GameObject;
                deathAnimationLoader = obj.GetComponent<DeathAnimationLoader>();
            }
        }

        public RuntimeAnimatorController getDeathAnimator(BodyParts bodyParts)
        {
            setUpDeathAnimationLoader();
            candidates.Clear();

            foreach (DeathAnimationData data in deathAnimationLoader.deathAnimationDatas)
            {
                foreach (BodyParts body in data.bodyParts)
                {
                    if (bodyParts == body)
                    {
                        candidates.Add(data.deathController);
                        break;
                    }
                }
            }
            int index = Random.Range(0, candidates.Count);
            return candidates[index];
        }
    }
}
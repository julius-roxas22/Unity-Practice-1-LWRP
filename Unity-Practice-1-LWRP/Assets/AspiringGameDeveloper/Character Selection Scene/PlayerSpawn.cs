using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    public class PlayerSpawn : MonoBehaviour
    {
        public CharacterSelect characterSelect;
        private string characterName;

        private void Awake()
        {
            switch (characterSelect.characterSelectType)
            {
                case CharacterSelectType.YELLOW:
                    {
                        characterName = "Y Bot - Yellow";
                    }
                    break;
                case CharacterSelectType.BLUE:
                    {
                        characterName = "Y Bot - Blue";
                    }
                    break;
                case CharacterSelectType.RED:
                    {
                        characterName = "Y Bot - Red";
                    }
                    break;
            }

            GameObject obj = Instantiate(Resources.Load(characterName, typeof(GameObject))) as GameObject;
            obj.transform.position = transform.position;

            Cinemachine.CinemachineVirtualCamera[] cameras = FindObjectsOfType<Cinemachine.CinemachineVirtualCamera>();
            foreach (Cinemachine.CinemachineVirtualCamera c in cameras)
            {
                CharacterControl control = CharacterManager.getInstance.getCharacter(characterSelect.characterSelectType);
                Collider target = control.getPart("Spine");
                c.LookAt = target.transform;
                c.Follow = target.transform;
            }

        }
    }
}
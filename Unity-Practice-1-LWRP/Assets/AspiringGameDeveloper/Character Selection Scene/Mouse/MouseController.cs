using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    public class MouseController : MonoBehaviour
    {
        private RaycastHit hit;
        private Ray ray;

        public CharacterSelect characterSelect;
        public CharacterSelectType characterSelectType;

        private void Update()
        {
            ray = CameraManager.getInstance.mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                CharacterControl control = hit.collider.GetComponent<CharacterControl>();

                if (null != control)
                {
                    characterSelectType = control.characterSelectType;
                }
                else
                {
                    characterSelectType = CharacterSelectType.NONE;
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (characterSelectType != CharacterSelectType.NONE)
                {
                    characterSelect.characterSelectType = characterSelectType;
                }
                else
                {
                    characterSelect.characterSelectType = CharacterSelectType.NONE;
                }
            }

        }
    }
}
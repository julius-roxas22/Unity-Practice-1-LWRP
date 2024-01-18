using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    public class MouseController : MonoBehaviour
    {
        private RaycastHit hit;
        private Ray ray;
        private SelectedLight selectedSpotLight;
        private HoverLight hoverSpotLight;

        public CharacterSelect characterSelectData;
        public CharacterSelectType characterSelectType;

        private void Awake()
        {
            characterSelectData.characterSelectType = CharacterSelectType.NONE;
            selectedSpotLight = FindObjectOfType<SelectedLight>();
            hoverSpotLight = FindObjectOfType<HoverLight>();
        }

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
                    characterSelectData.characterSelectType = characterSelectType;
                    selectedSpotLight.selectedSpotLight.enabled = true;
                    selectedSpotLight.transform.position = hoverSpotLight.transform.position;
                }
                else
                {
                    characterSelectData.characterSelectType = CharacterSelectType.NONE;
                    selectedSpotLight.selectedSpotLight.enabled = false;
                }
            }

        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    public class HoverLight : MonoBehaviour
    {
        public Vector3 offset;

        private CharacterControl characterHoverSelected;
        private MouseController mouseHover;
        //   private Vector3 targetPosition;
        private Light hoverSpotLight;

        private void Awake()
        {
            mouseHover = FindAnyObjectByType<MouseController>();
            hoverSpotLight = GetComponentInChildren<Light>();
        }

        private void Update()
        {
            if (mouseHover.characterSelectType == CharacterSelectType.NONE)
            {
                characterHoverSelected = null;
                hoverSpotLight.enabled = false;
            }
            else
            {
                lightUpSelectedCharacter();
            }
        }

        private void lightUpSelectedCharacter()
        {
            hoverSpotLight.enabled = true;

            if (null == characterHoverSelected)
            {
                characterHoverSelected = CharacterManager.getInstance.getCharacter(mouseHover.characterSelectType);
                transform.position = characterHoverSelected.transform.position + characterHoverSelected.transform.TransformDirection(offset);
            }

        }
    }
}
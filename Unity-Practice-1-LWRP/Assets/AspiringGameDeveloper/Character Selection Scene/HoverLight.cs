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
        private Vector3 targetPosition;
        private Light spotLight;

        private void Awake()
        {
            mouseHover = FindAnyObjectByType<MouseController>();
            spotLight = GetComponentInChildren<Light>();
        }

        private void Update()
        {
            if (mouseHover.characterSelectType == CharacterSelectType.NONE)
            {
                characterHoverSelected = null;
                spotLight.enabled = false;
            }
            else
            {
                lightUpSelectedCharacter();
            }
        }

        private void lightUpSelectedCharacter()
        {
            spotLight.enabled = true;

            if (null == characterHoverSelected)
            {
                characterHoverSelected = CharacterManager.getInstance.getCharacter(mouseHover.characterSelectType);
                transform.position = characterHoverSelected.transform.position + characterHoverSelected.transform.TransformDirection(offset);
            }

        }
    }
}
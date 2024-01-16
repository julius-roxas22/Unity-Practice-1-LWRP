using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    public class CharacterManager : Singleton<CharacterManager>
    {
        public List<CharacterControl> characterControls = new List<CharacterControl>();

        public CharacterControl getCharacter(CharacterSelectType characterSelectType)
        {
            foreach (CharacterControl control in characterControls)
            {
                if (control.characterSelectType == characterSelectType) return control;
            }
            return null;
        }
    }
}
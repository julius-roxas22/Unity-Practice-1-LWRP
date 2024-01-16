using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    public enum CharacterSelectType
    {
        NONE,
        YELLOW,
        RED,
        BLUE
    }

    [CreateAssetMenu(fileName = "Character Select Data" , menuName = "AspiringGameDev/CharacterSelectData/CharacterSelect")]
    public class CharacterSelect : ScriptableObject
    {
        public CharacterSelectType characterSelectType;
    }

}
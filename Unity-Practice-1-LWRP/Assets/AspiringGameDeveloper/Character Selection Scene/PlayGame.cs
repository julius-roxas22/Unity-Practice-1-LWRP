using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    public class PlayGame : MonoBehaviour
    {
        public CharacterSelect characterSelect;
        void Update()
        {
            if (Input.GetKey(KeyCode.Return))
            {
                if (characterSelect.characterSelectType != CharacterSelectType.NONE)
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(AllScenes.Main_Sample.ToString());
                }
                else
                {
                    Debug.Log("Selecte Character first before take the battle.");
                }
            }
        }
    }
}
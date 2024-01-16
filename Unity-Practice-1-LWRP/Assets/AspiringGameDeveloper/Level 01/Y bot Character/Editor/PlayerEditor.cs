using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AspringGameProgrammer
{
    [CustomEditor(typeof(CharacterControl))]
    public class PlayerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            CharacterControl control = (CharacterControl)target;

            if (GUILayout.Button("Setup RagdollParts"))
            {
                control.setRagdollParts();
            }
        }
    }
}
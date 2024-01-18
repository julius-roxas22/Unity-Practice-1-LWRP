using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AspringGameProgrammer
{
    public class SelectedLight : MonoBehaviour
    {
        public Light selectedSpotLight;
        private void Awake()
        {
            selectedSpotLight = GetComponentInChildren<Light>();
            selectedSpotLight.enabled = false;
        }
    }

}
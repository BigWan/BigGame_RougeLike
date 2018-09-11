using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BigRogue.Avatar;

namespace BigRogue.UI {


    public class AvatarUI : MonoBehaviour {

        private AvatarSetter avSetter;

        private AvatarPartSelector[] selectors;


        private void Awake() {
            avSetter = FindObjectOfType<AvatarSetter>();

            selectors = GetComponentsInChildren<AvatarPartSelector>();
            
        }


    }

}
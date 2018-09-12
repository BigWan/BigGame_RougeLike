using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BigRogue.Avatar;

namespace BigRogue.UI {


    public class AvatarUI : MonoBehaviour {

        private AvatarSetter avSetter;

        private AvatarPartSelector[] selectors;

        public Dropdown sexDropDown;


        private void Awake() {
            avSetter = FindObjectOfType<AvatarSetter>();
            
            selectors = GetComponentsInChildren<AvatarPartSelector>();
            
        }

        private void Start() {
            sexDropDown.value = 1;
        }

    }

}
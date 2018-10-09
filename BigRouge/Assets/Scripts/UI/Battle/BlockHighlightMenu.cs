using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BigRogue {

    public class BlockHighlightMenu : MonoBehaviour {

        [SerializeField] private Button confirm;
        [SerializeField] private Button cancel;

        public void AddListeners(UnityAction confirmAction, UnityAction cancelAction ) {
            confirm.onClick.AddListener(confirmAction);
            cancel.onClick.AddListener(cancelAction);
        }

        public void RemoveListeners() {
            confirm.onClick.RemoveAllListeners();
            cancel.onClick.RemoveAllListeners();
        }

    }
}

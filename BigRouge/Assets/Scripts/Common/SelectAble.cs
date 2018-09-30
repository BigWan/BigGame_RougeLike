using UnityEngine;
using System.Collections;

namespace BigRogue {


    /// <summary>
    /// 可以被点击
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class SelectAble : MonoBehaviour {

        /// <summary>
        /// 选中时显示的Prefab
        /// </summary>
        public GameObject selectPrefab;

        private GameObject selectgo;
        /// <summary>
        /// 是否被选中
        /// </summary>
        public bool selected;

        private void OnMouseDown() {

            if (selected)
                Deselect();
            else
                Select();
        }


        void Select() {
            selected = true;
            selectgo = Instantiate(selectPrefab);
            selectgo.transform.SetParent(transform);
            selectgo.transform.localPosition = Vector3.up * 2f;

        }
        void Deselect() {
            selected = true;
            Destroy(selectgo);

        }


        private void OnMouseEnter() {
            
        }

        private void OnMouseExit() {
            
        }



    }
}

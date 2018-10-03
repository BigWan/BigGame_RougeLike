using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
namespace BigRogue {

    /// <summary>
    /// 可以被点选
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class SelectAble : MonoBehaviour {

        /// <summary>
        /// 选中时显示的Prefab
        /// </summary>
        public GameObject selectPrefab;

        public System.Action SelectEventHandler;

        // Refs
        private GameObject selectgo;
        /// <summary>
        /// 是否被选中
        /// </summary>
        private bool selected;

        private void OnMouseDown() {
            //if (!aviable) return;
            if (EventSystem.current.IsPointerOverGameObject()) return;
            if (selected)
                Deselect();
            else
                Select();
        }

        public void Select() {
            selected = true;
            selectgo = Instantiate(selectPrefab);
            selectgo.transform.SetParent(transform);
            selectgo.transform.localPosition = Vector3.zero; ;

            SelectEventHandler?.Invoke();
        }

        public void Deselect() {
            selected = false;
            Destroy(selectgo);
        }

        


    }
}

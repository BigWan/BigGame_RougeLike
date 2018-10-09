using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace BigRogue.Ground {



    /// <summary> BLock的选择框 </summary>
    [RequireComponent(typeof(Collider))]
    public class BlockHightLight : MonoBehaviour {

        private Block block;
        private Actor actor;

        public void SetData(Block block,Actor actor) {
            this.block = block;
            this.actor = actor;
        }

        void OnMouseDown() {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            actor.SetMoveTarget(block);
            //Debug.Log(block.coord);
            actor.StartMove();
            //actor.battleManager.battleUI.PopUpSelectionBar(actor,Camera.main.WorldToScreenPoint( this.transform.position));
        }

    }

}
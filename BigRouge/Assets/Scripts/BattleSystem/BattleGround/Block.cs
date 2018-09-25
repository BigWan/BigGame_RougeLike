using UnityEngine;
using System.Collections;
using cakeslice;

namespace BigRogue.BattleSystem {

    /// <summary>
    /// 格子高亮类型
    /// </summary>
    public enum BlockHightLightType {
        Normal = 0,
        Gray = 1,
        Red = 2
    }

    /// <summary>
    /// 地图方块(一个Cube所代表的地形方块)
    /// </summary>
    [RequireComponent(typeof(BoxCollider))]
    public class Block : Entity {

        private BattleGround bg;

        private Outline outline;

        private void Awake() {
            outline = GetComponentInChildren<Outline>();
            if (outline == null)
                throw new UnityException("没有找到高亮组件");

            
        }

        private void Start() {
            outline.enabled = false;
        }
        //private void OnMouseDown() {
        //    //Debug.Log(transform.localPosition);
        //}

        public void HighLight(int index) {
            outline.color = index;
            outline.enabled = true;
        }

        public void CloseHighLight() {
            outline.enabled = false;
        }


    }
}

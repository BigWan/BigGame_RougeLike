using UnityEngine;
using System.Collections;
using cakeslice;
using DG.Tweening;
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


        private bool selected;

        public BattleGround battleGround;

        private Outline outline;

        public float edgeLength = 1f;

        private void Awake() {
            outline = GetComponentInChildren<Outline>();
            if (outline == null)
                throw new UnityException("没有找到高亮组件");
        }

        private void Start() {
            outline.enabled = false;
        }

        public void HighLight(int index) {
            outline.color = index;
            outline.enabled = true;
        }

        public void CloseHighLight() {
            outline.enabled = false;
        }

        public void OnMouseDown() {
            if (selected)
                DeSelect();
            else
                Select();

            battleGround.SelectBlock(this);
        }


        public void Select() {
            selected = true;
            HighLight(2);
        }

        public void DeSelect() {
            selected = false;
            CloseHighLight();
        }

    }

}

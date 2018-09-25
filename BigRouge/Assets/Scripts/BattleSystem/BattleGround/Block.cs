using UnityEngine;
using System.Collections;

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


        private void OnMouseDown() {
            Debug.Log(transform.localPosition);
        }


        public void HighLight(BlockHightLightType type) {
            transform.localScale *= 0.8f;
        }

    }
}

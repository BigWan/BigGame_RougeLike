using UnityEngine;
using System.Collections;
using DG.Tweening;
using System;
using BigRogue.Ground;

namespace BigRogue.Ground {

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

        private BoxCollider boxCollider;

        public BattleGround battleGround;



        private void Awake() {
            boxCollider = GetComponent<BoxCollider>();
        }

        
    }

}

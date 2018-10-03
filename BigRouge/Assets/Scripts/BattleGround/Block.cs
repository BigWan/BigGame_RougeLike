using UnityEngine;
using System.Collections;
using DG.Tweening;
using System;

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
    [RequireComponent(typeof(SelectAble))]
    public class Block : Entity {

        private SelectAble selectAble;
        private BoxCollider boxCollider;

        public BattleGround battleGround;



        private void Awake() {
            selectAble = GetComponent<SelectAble>();
            boxCollider = GetComponent<BoxCollider>();
            selectAble.SelectEventHandler += OnSelect;
        }


        void OnSelect() {
            battleGround.SelectBlock(this);
        }

        public void Deselect() {
            selectAble.Deselect();
        }




    }

}

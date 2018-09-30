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
    public class Block : Entity , ISelectAble{


        private bool selected;

        public BattleGround battleGround;


        public void OnMouseDown() {
            if (selected)
                Deselect();
            else
                Select();

            battleGround.SelectBlock(this);
        }


        #region "ISelectAble"

        public void Select() {
            selected = true;
        }

        public void Deselect() {
            selected = false;
        }

        public Action OnSelect() {
            throw new NotImplementedException();
        }

        public Action OnDeselect() {
            throw new NotImplementedException();
        }
        #endregion
    }

}

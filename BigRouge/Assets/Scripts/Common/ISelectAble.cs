using UnityEngine;
using System.Collections;
using System;
namespace BigRogue {


    /// <summary>
    /// 可以被选择的接口
    /// </summary>
    public interface ISelectAble {
        
        System.Action OnSelect();
        System.Action OnDeselect();

        void Select();
        void Deselect();

    }
}
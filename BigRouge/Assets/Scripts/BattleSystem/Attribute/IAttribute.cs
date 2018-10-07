using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BigRogue.BattleSystem {
    
    /// <summary>
    /// 拥有属性的接口
    /// </summary>
    public interface IAttribute {

        List<AttributeModifer> attributeModifiers { get; set; }



        void OnChange();

    }
}

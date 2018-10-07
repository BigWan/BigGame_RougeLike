using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigRogue.BattleSystem;
using System;

namespace BigRogue.ItemSystem {

    /// <summary>
    /// 道具
    /// </summary>
    public class Item {


    }




    public class Equip : Item, IAttribute {


        #region "IAttribute"

        #endregion

        List<AttributeModifer> IAttribute.attributeModifiers {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        void IAttribute.OnChange() {
            throw new NotImplementedException();
        }
    }
}

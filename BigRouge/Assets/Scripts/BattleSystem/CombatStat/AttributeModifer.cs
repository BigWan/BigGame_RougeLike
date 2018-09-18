using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigRogue.BattleSystem {

    public enum ModifierType {
        value,
        ratio,
        value1,
        ratio1
    }

    /// <summary>
    /// 属性修改器
    /// </summary>
    public class AttributeModifer {

        public string name;          // 修改器的名字
        public float modifierValue;  // 属性改值
        public float modifierRatio;  // 属性改百分比

    }
}
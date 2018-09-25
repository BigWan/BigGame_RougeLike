using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using UnityEngine;
using BigRogue.Persistent;

namespace BigRogue.BattleSystem {

    public enum ModifierType {
        BaseValue = 0,
        BaseScale = 1,
        ExtraValue = 2,
        ExtraScale = 3,
        MoreValue = 4,
        MoreScale = 5,
    }

    /// <summary>
    /// 游戏中加属性的东西
    /// </summary>
    public class AttributeModifer {
        public int attrID;              // 属性ID

        public string name {
            get {
                return AttributeDataHandler.GetRecord(attrID).name;
            }
        }

        public string source;           // 修改器来源
        public ModifierType type;       // 修改属性的哪一项值
        public float value;             // 改多少?正增负减


        public override string ToString() {
            return $"attrID = {attrID},name = {name},source = {source},type = {type},value = {value}";
        }
    }
}
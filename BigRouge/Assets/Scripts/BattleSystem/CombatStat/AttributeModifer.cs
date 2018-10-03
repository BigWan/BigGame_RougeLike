using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using UnityEngine;
using BigRogue.Persistent;

namespace BigRogue.BattleSystem {

    /// <summary>
    /// 属性修改器的类型(计算箱体归属)
    /// 0. 基础值加减
    /// 1. 基础值百分比加减
    /// 2. 额外值加减
    /// 3. 额外百分比加减
    /// 4. 更多值加减
    /// 5. 更多值百分比加减
    /// </summary>
    public enum ModifierType {
        BaseValue = 0,
        BaseScale = 1,
        ExtraValue = 2,
        ExtraScale = 3,
        MoreValue = 4,
        MoreScale = 5,
    }

    /// <summary>
    /// 属性修改器对象
    /// </summary>
    public class AttributeModifer {
        public int attrID;              // 属性ID

        public string name {
            get {
                return AttributeDataHandler.GetRecord(attrID).name;
            }
        }

        public string code;             // 修改器来源(原则上唯一,但是不作为主键索引)
        public ModifierType type;       // 修改器类型
        public float value;             // 改多少?正增负减


        public override string ToString() {
            return $"attrID = {attrID},name = {name},source = {code},type = {type},value = {value}";
        }
    }
}
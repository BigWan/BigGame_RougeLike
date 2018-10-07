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
    [Serializable]
    public class AttributeModifer {

        static int nextGuid = 0;

        private int guid; 
        public int attrID;              // 属性ID

        public string name {
            get {
                return AttributeDataHandler.GetRecord(attrID).name;
            }
        }

        /// <summary>
        /// TODO 如何保证code唯一性,同一件装备如何保证生成的属性修改器ID 不变
        /// </summary>
        public string path;             // 修改器来源(原则上唯一,但是不作为主键索引)
        public ModifierType type;       // 修改器类型
        public float value;             // 值,区分正负

        public AttributeModifer() {
            guid = nextGuid;
            nextGuid++;
        }

        public AttributeModifer(string path,int attrID, ModifierType type,float value ):this() {
            this.path = path;
            this.attrID = attrID;
            this.type = type;
            this.value = value;
        }

        public override string ToString() {
            return $"attrID = {attrID},name = {name},source = {path},type = {type},value = {value}";
        }


        public override bool Equals(object obj) {
            if (!(obj is AttributeModifer)) return false;
            return guid == (obj as AttributeModifer).guid;
        }

        public override int GetHashCode() {
            return guid;
        }
    }
}
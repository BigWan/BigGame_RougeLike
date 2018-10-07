using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigRogue.Persistent;
using UnityEngine;

namespace BigRogue.BattleSystem {


    /// <summary>
    /// 单条属性类
    /// 属性的定义:
    ///     属性是一个集合,内部由所有的属性修改器构成,属性修改器是属性的值的来源
    ///     装备上的属性由一个list管理
    /// </summary>
    [Serializable]
    public class Attribute {

        public int attrID;
        public string path;// 属性的路径,类似XPath
        public AttributeRecord attrInfo;
        //public Action ChangeHandler;
        public float value;

        List<AttributeModifer> modifiers;   // 本属性的属性修改器列表

        private Dictionary<ModifierType, float> modValues;

        Attribute() {
            modValues = new Dictionary<ModifierType, float>();
            modifiers = new List<AttributeModifer>();
        }


        public Attribute(int attrID, string code = "nil"):this() {
            attrInfo = AttributeDataHandler.GetRecord(attrID);
            if (attrInfo.id == -1) throw new UnityEngine.UnityException($"不存在这个属性{attrID}");
            this.attrID = attrInfo.id;
            this.path = code;
            value = 0;
        }


        public Attribute(AttributeRecord record):this() {
            this.attrID = record.id;
            this.path = record.code;
        }

        void Calculate() {

            modValues.Clear();

            foreach (var ev in System.Enum.GetValues(typeof(ModifierType))) {
                modValues.Add((ModifierType)ev, 0);
            }

            if (modifiers.Count <= 0) { value = 0; return; }
            
            for (int i = 0; i < modifiers.Count; i++) {
                if (!modValues.ContainsKey(modifiers[i].type))
                    modValues.Add(modifiers[i].type, 0);
                modValues[modifiers[i].type] = modValues[modifiers[i].type] + modifiers[i].value;
            }

            float baseValue = modValues[ModifierType.BaseValue] * (1 + modValues[ModifierType.BaseScale]);
            float extraValue = (baseValue + modValues[ModifierType.ExtraValue]) * (1 + modValues[ModifierType.ExtraScale]);
            float moreValue = (extraValue + modValues[ModifierType.MoreValue]) * (1 + modValues[ModifierType.MoreScale]);

            value = moreValue;
        }

        /// <summary>
        /// 添加修改器
        /// </summary>
        /// <param name="mod"></param>
        public void AddModifer(AttributeModifer mod) {
            if (mod.attrID != attrID) return;
            modifiers.Add(mod);
            Calculate();
            //ChangeHandler?.Invoke();
        }

        public void AddModifiers(List<AttributeModifer> mods) {
            foreach (var mod in mods) {
                if (mod.attrID != attrID) continue;
                modifiers.Add(mod);
            }
            Calculate();
        }

        /// <summary>
        /// 删除修改器
        /// </summary>
        /// <param name="mod"></param>
        public void RemoveModifer(AttributeModifer mod) {
            if (modifiers.Contains(mod)) {
                modifiers.Remove(mod);
                Calculate();
            } 
            //ChangeHandler?.Invoke();
        }

        public void RemoveModifiers(List<AttributeModifer> modifers) {
            foreach (var mod in modifers) {
                if (modifiers.Contains(mod))
                    modifiers.Remove(mod);
            }
            Calculate();
        }

    }
}
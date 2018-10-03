using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BigRogue.BattleSystem {


    /// <summary>
    /// 单条属性类
    /// 属性的定义:
    ///     属性是一个集合,内部由所有的属性修改器构成,属性修改器是属性的值的来源
    /// </summary>
    public class Attribute {

        public int attrID;

        public Action ChangeHandler;

        public float value;

        public List<AttributeModifer> modifiers;   // 属性修改器

        /// <summary>
        /// 计算属性的值
        /// </summary>
        /// <returns></returns>
        public void CalculateValue() {
            if (modifiers.Count <= 0) { value = 0; return; }

            Dictionary<ModifierType, float> modValues = new Dictionary<ModifierType, float>();
            for (int i = 0; i < modifiers.Count; i++) {
                modValues[modifiers[i].type] = modValues[modifiers[i].type] + modifiers[i].value;
            }

            float baseValue = modValues[ModifierType.BaseValue] * (1 + modValues[ModifierType.BaseScale]);

            float extraValue = (baseValue + modValues[ModifierType.ExtraValue]) * (1 + modValues[ModifierType.ExtraScale]);

            float moreValue = (extraValue + modValues[ModifierType.MoreValue]) * (1 + modValues[ModifierType.MoreScale]);

            value = moreValue;
        }

        public void AddModifer(AttributeModifer mod) {
            modifiers.Add(mod);
            CalculateValue();
            ChangeHandler?.Invoke();
        }

        public void RemoveModifer(AttributeModifer mod) {
            modifiers.Remove(mod);
            CalculateValue();
            ChangeHandler?.Invoke();
        }

        
    }
}
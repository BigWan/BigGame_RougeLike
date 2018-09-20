using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BigRogue.BattleSystem {
    
    /// <summary>
    /// 玩家所有属性
    /// 
    /// 
    /// </summary>
    public class CombatState {

        private Dictionary<int,Attribute> attributes;
                        
        CombatState() {
            attributes = new Dictionary<int, Attribute>();
        }


        /// <summary>
        /// 获取属性的值
        /// </summary>
        /// <param name="attrID"></param>
        /// <returns></returns>
        public float GetAttr(int attrID) {
            return attributes[attrID].value;
        }
        public float GetAttr(string code) {
            int id = AttributeDataHandler.GetID(code);
            if (id == -1) return 0;
            return GetAttr(id);
        }

        /// <summary>
        /// 增加一条属性
        /// </summary>
        /// <param name="mod"></param>
        public void AddAttributeModifier(AttributeModifer mod) {
            attributes[mod.attrID].AddModifer(mod);
        }

        /// <summary>
        /// 减少一条属性
        /// </summary>
        /// <param name="mod"></param>
        public void RemoveAttributeModifier(AttributeModifer mod) {
            attributes[mod.attrID].RemoveModifer(mod);
        }

        /// <summary>
        /// 增加一系列属性
        /// </summary>
        /// <param name="mods"></param>
        public void AppendAttributes(AttributeModifer[] mods) {
            for (int i = 0; i < mods.Length; i++) {
                AddAttributeModifier(mods[i]);
            }
        }



    }

}

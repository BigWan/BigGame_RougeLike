using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigRogue.Persistent;


namespace BigRogue.BattleSystem {
    
    /// <summary>
    /// 属性组
    /// 属性的集合,
    /// 
    /// </summary>
    public class AttributeGroup {

        /// <summary>
        /// 属性列表
        /// </summary>
        private Dictionary<int,Attribute> attributes;


        public AttributeGroup() {
            attributes = new Dictionary<int, Attribute>();
            BuildAttribute();
        }

        void AddAttribute(Attribute attr) {
            if (attributes.ContainsKey(attr.attrID)) {
                throw new UnityEngine.UnityException("不能重复添加属性类");
            }
            attributes.Add(attr.attrID, attr);
        }

        /// <summary>
        /// 根据配置表构建属性
        /// </summary>
        void BuildAttribute() {
            attributes.Clear();
            foreach (var item in AttributeDataHandler.GetRecords()) {
                attributes.Add(item.id,new Attribute(item));
            }
        }

        /// <summary>
        /// 获取属性的值
        /// </summary>
        /// <param name="attrID"></param>
        /// <returns></returns>
        public float GetAttrValue(int attrID) {
            return attributes[attrID].value;
        }
        public float GetAttrValue(string code) {
            int id = AttributeDataHandler.GetID(code);
            if (id == -1) return 0;
            return GetAttrValue(id);
        }

        /// <summary>
        /// 增加一条属性
        /// </summary>
        /// <param name="mod"></param>
        public void AddAttributeModifier(AttributeModifer mod) {

            attributes[mod.attrID].AddModifer(mod);
        }

        /// <summary>
        /// 移除属性
        /// </summary>
        /// <param name="mod"></param>
        public void RemoveAttributeModifier(AttributeModifer mod) {
            attributes[mod.attrID].RemoveModifer(mod);
        }

        /// <summary>
        /// 增加多条属性
        /// </summary>
        /// <param name="mods"></param>
        public void AddAttributeModifiers(AttributeModifer[] mods) {
            for (int i = 0; i < mods.Length; i++) {
                AddAttributeModifier(mods[i]);
            }
        }

        /// <summary>
        /// 注册一个加属性的玩意
        /// </summary>
        /// <param name="ia"></param>
        public void RegNewAttribute(IAttribute ia) {

            AddAttributeModifiers(ia.attributeModifiers.ToArray());
            //ia.AttributeChangeHandler += 
        }



        public override string ToString() {
            return base.ToString();
        }

        /// <summary>
        /// 格式化文本
        /// </summary>
        /// <returns></returns>
        public string FormatDesc() {
            return "";  
        }


    }

}

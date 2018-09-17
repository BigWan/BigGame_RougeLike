using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigRogue.BattleSystem {


    /// <summary>
    /// 战斗属性
    /// </summary>
    public class CombatStat{

        public int id { get; set; }
        public string name;
        public string code;
        public float defaultValue;
        public float min;
        public string desc;
        public float max;

    }

    /// <summary>
    /// 属性修改器
    /// </summary>
    public class AttributeModifer  {

        public string name;          // 修改器的名字
        public Type attributeType;   // 属性类型名
        public float modifierValue;  // 属性改值
        public float modifierRatio;  // 属性改百分比

    }


    public class Attribute {

        public readonly string name;
        public readonly string code;
        public readonly int min;
        public readonly int max;
        
        public float value;

        public List<AttributeModifer> modifiers;   // 属性修改器

        public Attribute(string name) {
            this.name = name.ToUpper();
        }
    }


    /// <summary>
    /// 玩家所有属性
    /// </summary>
    public class CombatStats {

        public Attribute hp;
        public Attribute strength;
        public Attribute intelligence;
        public Attribute dexterity;
        public Attribute atk;
        public Attribute def;

        CombatStats() {
            hp = new Attribute("HP");
            strength = new Attribute("STR");
            intelligence = new Attribute("INT");
            dexterity = new Attribute("DEX");
            atk = new Attribute("ATK");
            def = new Attribute("DEF");
        }
        


    }

}

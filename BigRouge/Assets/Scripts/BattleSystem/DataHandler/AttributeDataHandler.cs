using System.Collections;
using System.Collections.Generic;

namespace BigRogue.BattleSystem {

    /// <summary>
    /// 属性相关数据和配置
    /// </summary> 
    public static class AttributeDataHandler {

        static string attributeDateFile = "Texts/CombatStatData";

        static Dictionary<int, AttributeInfo> s_attrData;

        static AttributeDataHandler() {
            
            s_attrData = new Dictionary<int, AttributeInfo>();
            s_attrData = Util.SimpleCsv.OpenCsvAs<AttributeInfo>(attributeDateFile);
        }

        public static AttributeInfo GetRecord(int id) {
            if (s_attrData.ContainsKey(id)) {
                return s_attrData[id];
            }
            return AttributeInfo.empty;
        }

        public static int GetID(string code) {
            foreach (var item in s_attrData) {
                if (item.Value.code == code.ToUpper())
                    return item.Value.id;
            }
            return -1;
        }

    }
}
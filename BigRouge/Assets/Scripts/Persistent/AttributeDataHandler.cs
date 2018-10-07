using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BigRogue.Persistent {

    /// <summary>
    /// 属性相关数据和配置
    /// </summary> 
    public static class AttributeDataHandler {

        static string attributeDateFile = "Texts/AttributeData";

        static Dictionary<int, AttributeRecord> s_attrData;

        static AttributeDataHandler() {
            
            s_attrData = new Dictionary<int, AttributeRecord>();
            s_attrData = Util.SimpleCsv.OpenCsvAs<AttributeRecord>(attributeDateFile);
        }

        public static AttributeRecord GetRecord(int id) {
            if (s_attrData.ContainsKey(id)) {
                return s_attrData[id];
            }
            return AttributeRecord.empty;
        }

        public static int GetID(string code) {
            foreach (var item in s_attrData) {
                if (item.Value.code == code.ToUpper())
                    return item.Value.id;
            }
            return -1;
        }

        public static List<int> GetIDs() {
            return s_attrData.Keys.ToList<int>();
        }
        public static List<AttributeRecord> GetRecords() {
            return s_attrData.Values.ToList();
        }
    }
}
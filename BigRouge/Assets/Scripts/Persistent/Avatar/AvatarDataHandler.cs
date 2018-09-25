using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using BigRogue.Persistent;

namespace BigRogue.CharacterAvatar {

    /// <summary>
    /// 负责读取数据表
    /// 部件类型表(部件类型名字和部件挂点类型)
    /// 部件表(部件id,部件类型,部件资源)
    /// </summary>
    public static class AvatarDataHandler  {

        const string avatarDataFile = "Texts/AvatarData";

        static Dictionary<int, AvatarRecord> s_data;


        static AvatarDataHandler() {
            s_data = new Dictionary<int, AvatarRecord>();
            s_data = Util.SimpleCsv.OpenCsvAs<AvatarRecord>(avatarDataFile);
            //LoadAvatarData();
        }

        public static AvatarRecord GetRecord(int id) {
            if (s_data.ContainsKey(id))
                return s_data[id];
            else
                return AvatarRecord.empty;
        }


        public static List<int> SelectRecordIDs(AvatarPartType apt,SexType sex,string cat) {
            var result = from x in s_data
                         where (x.Value.avatarType == apt && (x.Value.sex == sex || x.Value.sex == SexType.None) && x.Value.category == cat)
                         select x.Key;
            return result.ToList<int>();
        }

        public static List<string> SelectCats(AvatarPartType apt,SexType sex) {
            var result = from x in s_data
                         where (x.Value.avatarType == apt && (x.Value.sex == sex || x.Value.sex == SexType.None))
                         select x.Value.category;
            return result.ToList<string>().Distinct().ToList();
        }

    }

}
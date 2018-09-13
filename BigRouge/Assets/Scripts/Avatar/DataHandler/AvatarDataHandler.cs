using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace BigRogue.CharacterAvatar {

    /// <summary>
    /// 负责读取数据表
    /// 部件类型表(部件类型名字和部件挂点类型)
    /// 部件表(部件id,部件类型,部件资源)
    /// </summary>
    public static class AvatarDataHandler {

        const string avatarDataFile = "Avatar/Texts/AvatarData";

        static Dictionary<int, AvatarRecord> s_avatarDatas;

        private static void LoadAvatarData() {

            string[] lines = Util.SimpleCsv.OpenCsv(avatarDataFile);
            if (lines.Length == 0)
                throw new UnityException($"avatardatas:{s_avatarDatas}没有数据");

            for (int i = 0; i < lines.Length; i++) {
                AvatarRecord record = new AvatarRecord(lines[i]);
                s_avatarDatas.Add(record.id, record);
            }
        }

        static AvatarDataHandler() {
            s_avatarDatas = new Dictionary<int, AvatarRecord>();
            LoadAvatarData();
        }

        public static AvatarRecord GetAvatarRecord(int id) {
            if (s_avatarDatas.ContainsKey(id))
                return s_avatarDatas[id];
            else
                return AvatarRecord.empty;
        }


        public static List<int> SelectRecordIDs(AvatarPartType apt,SexType sex,string cat) {
            var result = from x in s_avatarDatas
                         where (x.Value.avatarType == apt && (x.Value.sex == sex || x.Value.sex == SexType.None) && x.Value.category == cat)
                         select x.Key;
            return result.ToList<int>();
        }

        public static List<string> SelectCats(AvatarPartType apt,SexType sex) {
            var result = from x in s_avatarDatas
                         where (x.Value.avatarType == apt && (x.Value.sex == sex || x.Value.sex == SexType.None))
                         select x.Value.category;
            return result.ToList<string>().Distinct().ToList();
        }

    }

}
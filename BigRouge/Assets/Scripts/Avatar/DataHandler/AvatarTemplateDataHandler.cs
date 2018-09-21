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
    public static class AvatarTemplateDataHandler  {

        const string avatarDataFile = "Texts/AvatarTemplate";

        static Dictionary<int, AvatarTemplateRecord> s_avatarTemplateData;


        static AvatarTemplateDataHandler() {
            s_avatarTemplateData = new Dictionary<int, AvatarTemplateRecord>();
            s_avatarTemplateData = Util.SimpleCsv.OpenCsvAs<AvatarTemplateRecord>(avatarDataFile);
            //LoadAvatarData();
        }

        public static AvatarTemplateRecord GetRecord(int id) {
            if (s_avatarTemplateData.ContainsKey(id))
                return s_avatarTemplateData[id];
            else {
                AvatarTemplateRecord empty = new AvatarTemplateRecord();
                empty.id = -1;
                return empty;
            }
        }



    }

}
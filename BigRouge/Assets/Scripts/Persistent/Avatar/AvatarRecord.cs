using System;
using UnityEngine;
using BigRogue.CharacterAvatar;

namespace BigRogue.Persistent {

    public struct AvatarRecord :IRecord {

        public int id { get; set; }
        public AvatarPartType avatarType;
        public MountingType mountingType;
        public SexType sex;
        public string category;
        public string path;

        public static AvatarRecord empty { get {return new AvatarRecord(-1); } }

        public bool isEmpty() {
            return id == -1;
        }

        public AvatarRecord(
                int id,
                AvatarPartType avatarType = AvatarPartType.MainBody,
                MountingType mountingType=MountingType.None,
                SexType sex=SexType.None,
                string category = "",
                string path = "") {
            this.id = id;
            this.avatarType = avatarType;
            this.mountingType = mountingType;
            this.sex = sex;
            this.category = category;
            this.path = path;
        }

        //public AvatarRecord(string s) {
        //    try {
        //        string[] cells = s.Split(',');
        //        int i = 0;
        //        id = int.Parse(cells[i]); i++;
        //        avatarType = (AvatarPartType)Enum.Parse(typeof(AvatarPartType), cells[i]); i++;
        //        mountingType = (MountingType)Enum.Parse(typeof(MountingType), cells[i]); i++;
        //        sex = (SexType)Enum.Parse(typeof(SexType), cells[i]); i++;
        //        category = cells[i]; i++;
        //        path = cells[i]; i++;

        //    } catch (Exception) {

        //        throw new UnityException($"解析数据行错误:{s}");
        //    }
        //}
            

        public void InitFromLine(string s) {
            try {
                string[] cells = s.Split(',');
                int i = 0;
                id = int.Parse(cells[i]); i++;
                avatarType = (AvatarPartType)Enum.Parse(typeof(AvatarPartType), cells[i]); i++;
                mountingType = (MountingType)Enum.Parse(typeof(MountingType), cells[i]); i++;
                sex = (SexType)Enum.Parse(typeof(SexType), cells[i]); i++;
                category = cells[i]; i++;
                path = cells[i]; i++;

            } catch (Exception) {

                throw new UnityException($"解析数据行错误:{s}");
            }
        }
    }
}
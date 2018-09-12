using System;
using UnityEngine;
namespace BigRogue.Avatar {


    public struct AvatarRecord {

        public int id;
        public AvatarPartType avatarType;
        public MountingType mountingType;
        public SexType sex;
        public string category;
        public string path;

        public static AvatarRecord empty = new AvatarRecord(-1);

        public bool isEmpty() {
            if (id == -1)
                return true;
            return false;
        }

        public AvatarRecord(
                int id,
                AvatarPartType avatarType = AvatarPartType.MainBody,
                MountingType mountingType=MountingType.None,
                SexType sex=SexType.None,
                string category="",
                string path="") {
            this.id = id;
            this.avatarType = avatarType;
            this.mountingType = mountingType;
            this.sex = sex;
            this.category = category;
            this.path = path;
        }

        public AvatarRecord(string s) {

            try {

                string[] cells = s.Split(',');
                int i = 0;
                id = int.Parse(cells[i]); i++;
                avatarType =(AvatarPartType)Enum.Parse(typeof(AvatarPartType), cells[i]); i++;
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
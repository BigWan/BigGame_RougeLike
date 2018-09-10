using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.Avatar {

    public enum AvatarPartType {
        Body = 1,
        Beard = 2,
        Ears = 3,
        Hair = 4,
        Horns = 5
    }

    public enum SexType {
        Both = 0,
        Female = 1,
        Male = 2
    }


    /// <summary>
    /// 负责读取数据表
    /// </summary>
    public static class AvatarDataHandler {

        public static string avatarDataPath = "Avatar/Texts/";


        /// <summary>
        /// Avatar 配置文件名
        /// </summary>
        static Dictionary<AvatarPartType, string> avatarDataFileNames;

        /// <summary>
        /// Avatar 配置数据
        /// </summary>
        static Dictionary<AvatarPartType, AvatarData> avatarDatas;



        static AvatarDataHandler() {
            avatarDataFileNames = new Dictionary<AvatarPartType, string>();
            avatarDatas = new Dictionary<AvatarPartType, AvatarData>();

            InitFileNames();
            ReloadAvatarDatas();
        }

        /// <summary>
        /// 构造文件名
        /// </summary>
        static void InitFileNames() {
            foreach (int avatarPartTypeID in System.Enum.GetValues(typeof(AvatarPartType))) {
                AvatarPartType item = (AvatarPartType)avatarPartTypeID;
                avatarDataFileNames.Add(
                    item,
                    "Avatar" + item.ToString()
                );
            }
        }

        /// <summary>
        /// 重新加载配置文件
        /// </summary>
        public static void ReloadAvatarDatas() {
            string path;
            AvatarData data;
            avatarDatas.Clear();
            foreach (int avatarPartTypeID in System.Enum.GetValues(typeof(AvatarPartType))) {
                AvatarPartType avatarPartType = (AvatarPartType)avatarPartTypeID;

                path = avatarDataFileNames[avatarPartType];

                data = new AvatarData(avatarPartType.ToString(), avatarDataPath + path);
                avatarDatas.Add(avatarPartType, data);
            }

        }

        /// <summary>
        /// 获取资源路径
        /// </summary>
        /// <param name="avatarPartTypeID">部件的类型ID</param>
        /// <param name="avatarID">部件的ID</param>
        public static (MountPointType,string) GetAvatarInfo(AvatarPartType partType, int avatarID) {
            if (avatarDatas == null) ReloadAvatarDatas();
            if (avatarDatas == null || avatarDatas[partType] == null) throw new UnityException("数据异常!!!");
            AvatarRecord record = avatarDatas[partType][avatarID];

            return (record.mpt, record.path);
        }

        ///// <summary>
        ///// 返回空的资源
        ///// </summary>
        ///// <returns></returns>
        //public static List<string> GetNullResources() {
        //    List<string> result = new List<string>();
        //    foreach (int avatarPartTypeID in System.Enum.GetValues(typeof(AvatarPartType))) {
        //        foreach (var item in avatarDatas[(AvatarPartType)avatarPartTypeID]) {
        //            GameObject go = Resources.Load<GameObject>(item.Value);
        //            if(go ==null)
        //                result.Add(item.Value);
                    
        //        }

        //    }
        //    return result;
        //}




    }
}
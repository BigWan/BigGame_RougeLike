using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.Avatar {

    public enum AvatarPartType {
        Body  = 1,
        Beard = 2,
        Ears  = 3,
        Hari  = 4,
        Horn  = 5
    }

    public enum SexType {
        Both = 0,
        Female = 1,
        Male = 2
    }



    /// <summary>
    /// 负责读取数据表
    /// </summary>
    public static class AvatarDataUtil {

        public static string avatarDataPath = "Avatar/Texts/";

        public static string GetAvatarPath<T>(int id) where T: IAvatarData {
            return "";
        }   

	}



    public struct AvatarBodyRecord {
        public int id;
        public string name;
    }
    
    public struct AvatarBodyTable {

    }

}
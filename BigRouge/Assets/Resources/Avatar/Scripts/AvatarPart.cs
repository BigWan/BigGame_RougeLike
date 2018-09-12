using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.Avatar {




    public class AvatarPart :MonoBehaviour {
        
        public AvatarRecord avatarRecord;


        /// <summary>
        /// 双手皆可佩戴的武器要设置装备点是左手还是右手
        /// </summary>
        public MountingPoint mountPoint;




        //// 这个 Avatar 的类型
        //public string avatarPartTypeName {
        //    get {
        //        return apr.avatarPartTypeName;
        //    }
        //}

        //public int id {
        //    get {
        //        return apr.id;
        //    }
        //}



        //// 这个东西可以被挂在哪里
        //public MountingType mountingType {
        //    get {
        //        return AvatarDataHandler.GetMountingType(avatarPartTypeName);
        //    }
        //}




    }
}

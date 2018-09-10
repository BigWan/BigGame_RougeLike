using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.Avatar {

    /// <summary>
    /// 一个换装部件的基类
    /// </summary>
    public class AvatarPart : MonoBehaviour {

        public AvatarPartRecord apr { get; set; }


        // 这个 Avatar 的类型
        public string avatarPartTypeName {
            get {
                return apr.avatarPartTypeName;
            }
        }

        public int id {
            get {
                return apr.id;
            }
        }



        // 这个东西可以被挂在哪里
        public MountingType mountingType {
            get {
                return AvatarDataHandler.GetMountingType(avatarPartTypeName);
            }
        }


        

    }
}

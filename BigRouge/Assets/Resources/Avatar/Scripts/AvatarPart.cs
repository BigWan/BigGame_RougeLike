using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.Avatar {


    /// <summary>
    /// 一个换装部件的基类
    /// </summary>
    public class AvatarPartBase :MonoBehaviour {
        // 这个 Avatar 的类型
        public AvatarPartType avatarPartType;

        // 这个东西需要挂在哪里
        public MountPointType[] mountPoints;

        //public GameObject avatarGO;

    }
}

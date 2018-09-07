using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.Avatar {


    /// <summary>
    /// 一个换装部件的基类
    /// </summary>
    public class AvatarPartBase :MonoBehaviour {

        public AvatarPartType avatarPartType;

        public MountPointType[] mountPoints;

        //public GameObject avatarGO;

    }
}

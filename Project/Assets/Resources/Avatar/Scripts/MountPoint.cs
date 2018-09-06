using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BigRogue.Avatar {

    public enum MountPointType {
        Base,Head,Back,Left,Right,BothHand
    }

    /// <summary>
    /// 模型上面的挂点
    /// </summary>
    public class MountPoint : MonoBehaviour {

        public MountPointType mountPointType;

    }
}

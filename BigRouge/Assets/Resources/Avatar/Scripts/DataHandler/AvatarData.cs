using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.Avatar {

    // 配置表相关的内容
    public interface IAvatarData { }

    public struct AvatarDataBeard: IAvatarData {
        public int id;
        public string name;
    }


    public struct AvatarDataBody: IAvatarData {
        public int id;
        public string name;
    }

    public struct AvatarDataEars: IAvatarData {
        public int id;
        public string name;
    }


    public struct AvatarDataHair: IAvatarData {
        public int id;
        public string name;
    }

    public struct AvatarDataHorns: IAvatarData {
        public int id;
        public string name;
    }
}

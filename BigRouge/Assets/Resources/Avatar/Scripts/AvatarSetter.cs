using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BigRogue.Avatar {

    /// <summary>
    /// 界面上负责设置avatar参数
    /// </summary>
    [RequireComponent(typeof(Avatar))]
    public class AvatarSetter : MonoBehaviour {


        private Avatar avatar;


        private void Awake() {
            avatar = GetComponent<Avatar>();
        }

        public void SetAndBuildAvatarPart(string name,int id) {
            avatar.SetAndBuildAvatar(name, id);
        }

    }
}

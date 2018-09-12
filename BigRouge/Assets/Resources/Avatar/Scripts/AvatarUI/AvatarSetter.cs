﻿using System.Collections;
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

        public void SetAndBuildAvatarPart(AvatarSlot avSlot,int id) {
            avatar.SetAndBuildAvatar(avSlot, id);
        }

        public void SaveData() {
            avatar.SaveData();
        }


        public void ReadData() {
            avatar.ReadData();
        }

    }
}

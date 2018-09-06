using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.Avatar {

    public class Avatar : MonoBehaviour {

        [Header ("身体部分")]

        // avatar IDs
        public int bodyAvatarID;
        public int beardAvatarID;
        public int earsAvatarID;
        public int hornsAvatarID;
        public int hairAvatarID;

        // avatar Resources
        public BodyAvatar bodyAvatar;
        public GameObject beardAvatar;
        public GameObject earsAvatar;
        public GameObject hornsAvatar;
        public GameObject hairAvatar;


        // 装备部分
        /// <summary>
        /// 内衣ID,更换内衣会改变BodyAvatar和贴图
        /// </summary>
        public int underwearID;
        public int bodyMatID;
        public Material bodyMat;


        public int headEquipID; // 皇冠,帽子,头巾,头盔,面具
        public int bagEquipID; // 背包,麻袋,背篮
        public int wingEquipID; // 翅膀,神器
        public int jacketID;   // 衣服
        public int weaponID;   // 武器类型很多



        /// <summary>
        /// 创建BodyAvatar
        /// </summary>
        void CreateBodyAvatar() {
            bodyAvatar = Instantiate<BodyAvatar>(AvatarDataUtil.GetAvatarPartBody(bodyAvatarID));
            bodyAvatar.transform.SetParent(transform);
            bodyAvatar.bodyMaterial = bodyMat;
        }

        private void OnGUI() {
            if(GUI.Button(new Rect(50, 50, 50, 50), "ChangeBody")) {
                bodyAvatarID = 2;
            }
        }
    }
}
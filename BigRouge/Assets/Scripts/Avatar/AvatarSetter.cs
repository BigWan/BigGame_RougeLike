using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BigRogue.CharacterAvatar {

    /// <summary>
    /// 界面上负责设置avatar参数
    /// </summary>
    [RequireComponent(typeof(Avatar))]
    public class AvatarSetter : MonoBehaviour {

        public int mainbodyID,
            beardID,
            hairID,
            earsID,
            faceID,
            hornsID,
            wingID,
            bagID,
            mainHandID,
            offHandID;
        

        private Avatar avatar;


        private void Awake() {
            avatar = GetComponent<Avatar>();
        }

        private void Start() {
            SetAndBuildAvatarFromInspector();
        }

        public void SetAndBuildAvatarPart(AvatarSlot avSlot, int id) {
            avatar.SetAndBuildAvatar(avSlot, id);
        }

        public void SaveData() {
            avatar.SaveData();
        }


        public void ReadData() {
            avatar.ReadData();
        }


        [ContextMenu("BuildAvatar")]
        public void SetAndBuildAvatarFromInspector() {
            SetAndBuildAvatarPart(AvatarSlot.MainBody, mainbodyID);
            SetAndBuildAvatarPart(AvatarSlot.Beard, beardID);
            SetAndBuildAvatarPart(AvatarSlot.Hair, hairID);
            SetAndBuildAvatarPart(AvatarSlot.Ears, earsID);
            SetAndBuildAvatarPart(AvatarSlot.Face, faceID);
            SetAndBuildAvatarPart(AvatarSlot.Horns, hornsID);
            SetAndBuildAvatarPart(AvatarSlot.Wing, wingID);
            SetAndBuildAvatarPart(AvatarSlot.Bag, bagID);
            SetAndBuildAvatarPart(AvatarSlot.MainHand, mainHandID);
            SetAndBuildAvatarPart(AvatarSlot.OffHand, offHandID);
        }

        private void OnGUI() {
            if(GUI.Button(new Rect(800, 100, 100, 50),"RebuildAvatar")) {
                SetAndBuildAvatarFromInspector();
            }
        }

    }
}

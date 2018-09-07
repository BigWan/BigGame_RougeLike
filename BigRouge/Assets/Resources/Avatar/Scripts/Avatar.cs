using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.Avatar {

    public class Avatar : MonoBehaviour {

        [Header ("身体部分")]

        //Avatar ID
        Dictionary<AvatarPartType, int> avatarIDs;

        // Avatar Part 在场景中的引用
        Dictionary<AvatarPartType, GameObject> avatarGOs;


        public int GetAvatarID(AvatarPartType apt) {
            if (avatarIDs.ContainsKey(apt))
                return avatarIDs[apt];
            else
                return -1;
        }

        public void SetAvatarID(AvatarPartType apt,int id) {
            if (avatarIDs.ContainsKey(apt))
                avatarIDs[apt] = id;
            else
                avatarIDs.Add(apt, id);
        }

        public GameObject GetAvatarGameObject(AvatarPartType apt) {
            if (avatarGOs.ContainsKey(apt))
                return avatarGOs[apt];
            else
                return null;
        }

        public void SetAvatarGameObject(AvatarPartType apt,GameObject go) {
            if (avatarGOs.ContainsKey(apt))
                avatarGOs[apt] = go;
            else
                avatarGOs.Add(apt, go);
        }

        void Init() {
            avatarIDs = new Dictionary<AvatarPartType, int>();
            avatarGOs = new Dictionary<AvatarPartType, GameObject>();
        }

        private void Awake() {
            Init();
        }

        /// <summary>
        /// 根据Avatar 部件信息,组建Avatar
        /// </summary>
        public void BuildAvatar() {



        }

        public void BuildAvatarPart(AvatarPartType apt) {
            if (apt == AvatarPartType.Body)
                BuildBody();
            else
                BuildBody();
        }


        public void BuildBody() {
            AvatarPartType body = AvatarPartType.Body;
            if (GetAvatarID(AvatarPartType.Body) == -1) return;
            GameObject newBody = LoadAvatar(body, GetAvatarID(body));

            GameObject oldBody = GetAvatarGameObject(body);
            if (oldBody != null)
                Destroy(oldBody);

            GameObject go = Instantiate<GameObject>(newBody);
            go.transform.SetParent(transform, false);
            go.transform.localPosition = Vector3.zero;

            SetAvatarGameObject(body,go);

        }


        public static GameObject LoadAvatar(AvatarPartType apt, int aID) {
            string path = AvatarDataHandler.GetResourcePath(apt, aID);
            GameObject go = Resources.Load<GameObject>(path);
            if (go == null) throw new UnityException($"载入资源出错{path}");
            return go;
        }

        //// 装备部分
        ///// <summary>
        ///// 内衣ID,更换内衣会改变BodyAvatar和贴图
        ///// </summary>
        //public int underwearID;
        //public int bodyMatID;
        //public Material bodyMat;


        //public int headEquipID; // 皇冠,帽子,头巾,头盔,面具
        //public int bagEquipID; // 背包,麻袋,背篮
        //public int wingEquipID; // 翅膀,神器
        //public int jacketID;   // 衣服
        //public int weaponID;   // 武器类型很多





        private void OnGUI() {
            if (GUI.Button(new Rect(50, 50, 50, 50), "Build")) {                
                BuildBody();
            }

            for (int i = 0; i < 3; i++) {
                if(GUI.Button(new Rect(100, 100 + i * 50, 100, 50),$"设置为{i}号身体")) {
                    SetAvatarID(AvatarPartType.Body, i);
                }
            }

        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.Avatar {




    public class Avatar : MonoBehaviour {


        [Header("身体部分")]

        // key avatar enum
        // value avatarid
        Dictionary<string,int> allAvatars;

        Dictionary<string, AvatarPart> allAvatarPart;

        public int GetAvatarID(string apt) {
            if (allAvatars.ContainsKey(apt))
                return allAvatars[apt];
            else
                return -1;
        }

        public void SetAvatarID(string apt,int id) {
            if (allAvatars.ContainsKey(apt))
                allAvatars[apt] = id;
            else
                allAvatars.Add(apt, id);
        }


        public void SetAvatar(string apt, AvatarPart ap) {
            if (ap == null) {
                Destroy(allAvatarPart[apt].gameObject);
                return;
            }
            if (allAvatarPart.ContainsKey(apt)) {
                Destroy(allAvatarPart[apt].gameObject);
                allAvatarPart[apt] = ap;
            } else
                allAvatarPart.Add(apt, ap);
        }

        public AvatarPart GetAvatar(string apt) {
            if (allAvatarPart.ContainsKey(apt))
                return allAvatarPart[apt];
            else
                return null;
        }


        void Init() {
            allAvatars = new Dictionary<string, int>();
            allAvatarPart = new Dictionary<string, AvatarPart>();
        }

        private void Awake() {
            Init();
        }

        /// <summary>
        /// 根据Avatar 部件信息,组建Avatar
        /// </summary>
        public void BuildAllAvatar() {
            BuildBody();
            foreach (var item in allAvatars) {
                if (item.Key == "MainBody") continue;
                SetAvatar(item.Key, LoadAvatarPartRes(item.Value));
            }
        }

        void BuildBody() {

        }
         



        public AvatarPart LoadAvatarPartRes(int apID) {
            AvatarPartRecord apr = AvatarDataHandler.GetAvatarPartRecord(apID);

            MountingType mp = AvatarDataHandler.GetMountingType(apr.avatarPartTypeName);

            Debug.Log(apr.path);
            Debug.Log(apr.id);
            Debug.Log(apr.avatarPartTypeName);

            if (apr.id == -1) return null;

            GameObject prefab = Resources.Load<GameObject>(apr.path);

            if (prefab == null) {
                Debug.Log($"没有找到预制物体{apr.path}");
                return null;
            }

            GameObject go = Instantiate<GameObject>(prefab);



            AvatarPart ap = go.AddComponent<AvatarPart>();
            ap.apr = apr;

            return ap;

        }


        private void OnGUI() {
            if (GUI.Button(new Rect(300,300,300,300),"按钮")) {
                SetAvatarID("MainBody", 0);
                SetAvatarID("Beard", 20001);
                BuildAllAvatar();
            }
        }
    }
}
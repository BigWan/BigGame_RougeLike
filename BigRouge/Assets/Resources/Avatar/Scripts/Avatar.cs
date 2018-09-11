using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.Avatar {

    public class Avatar : MonoBehaviour {

        // key avatar enum
        // value avatarid
        Dictionary<string, int> m_allAvatarIDs;

        Dictionary<string, AvatarPart> m_allAvatarPart;

        AvatarBody m_bodyAvatar;

        //Material m_bodyMat;


        int GetAvatarID(string apt) {
            if (m_allAvatarIDs.ContainsKey(apt))
                return m_allAvatarIDs[apt];
            else
                return -1;
        }

        public void SetAvatarID(string apt, int id) {
            if (m_allAvatarIDs.ContainsKey(apt))
                m_allAvatarIDs[apt] = id;
            else
                m_allAvatarIDs.Add(apt, id);
        }


        void SetAvatar(string apt, AvatarPart ap) {

            if (m_allAvatarPart.ContainsKey(apt)) {
                //Destroy(m_allAvatarPart[apt].gameObject);
                m_allAvatarPart[apt] = ap;
            } else
                m_allAvatarPart.Add(apt, ap);
        }

        AvatarPart GetAvatar(string apt) {
            if (m_allAvatarPart.ContainsKey(apt))
                return m_allAvatarPart[apt];
            else
                return null;
        }


        void Init() {
            m_allAvatarIDs = new Dictionary<string, int>();
            m_allAvatarPart = new Dictionary<string, AvatarPart>();
        }

        private void Awake() {
            Init();
        }

        /// <summary>
        /// 根据Avatar 部件信息,组建Avatar
        /// </summary>
        public void BuildAllAvatar() {
            BuildBody();
            //BuildBodyMat();
            foreach (var item in m_allAvatarIDs) {
                BuildNormalAvatar(item.Key);
            }
        }

        /// <summary>
        /// 组建非身体部件的Avatar
        /// </summary>
        /// <param name="avatarPartTypeName"></param>
        void BuildNormalAvatar(string avatarPartTypeName) {
            if (m_bodyAvatar == null) return;
            if (!m_allAvatarIDs.ContainsKey(avatarPartTypeName)) return;
            if (avatarPartTypeName == "MainBody" ) {
                return;
            }
            int avID = m_allAvatarIDs[avatarPartTypeName];
            if (avID == -1) {
                SetDefaultAvatar(avatarPartTypeName);
                return;
            } 
            AvatarPart ap = LoadAvatarPart(avID);
            if (ap == null) {
                SetDefaultAvatar(avatarPartTypeName);
                return;
            }
            MountAvatarPart(ap);
            SetAvatar(avatarPartTypeName, ap);
        }

        /// <summary>
        /// 清除部件
        /// </summary>
        /// <param name="avatarPartTypeName"></param>
        void SetDefaultAvatar(string avatarPartTypeName) {
            if (avatarPartTypeName == "MainBody") {
                return;
            }
            if (avatarPartTypeName == "Underwear") {
                return;
            }
            if(m_allAvatarPart.ContainsKey(avatarPartTypeName))
                Destroy(m_allAvatarPart[avatarPartTypeName].gameObject);

            SetAvatarID(avatarPartTypeName, -1);
        }


        void BuildBody() {
            AvatarPart ap = LoadAvatarPart(m_allAvatarIDs["MainBody"]);
            MountAvatarPart(ap);
            SetAvatar("MainBody", ap);
            m_bodyAvatar = ap.gameObject.AddComponent<AvatarBody>();
        }


        void MountAvatarPart(AvatarPart ap) {

            switch (ap.mountingType) {
                case MountingType.Root:
                    ap.transform.SetParent(transform);
                    break;
                case MountingType.Base:
                    ap.transform.SetParent(m_bodyAvatar.GetMountingParent(MountingPoint.Base), false);
                    break;
                case MountingType.Head:
                    ap.transform.SetParent(m_bodyAvatar.GetMountingParent(MountingPoint.Head), false);
                    break;
                case MountingType.Back:
                    ap.transform.SetParent(m_bodyAvatar.GetMountingParent(MountingPoint.Back), false);
                    break;
                case MountingType.Left:
                    ap.transform.SetParent(m_bodyAvatar.GetMountingParent(MountingPoint.Left), false);
                    break;
                case MountingType.Right:
                    ap.transform.SetParent(m_bodyAvatar.GetMountingParent(MountingPoint.Right), false);
                    break;
                case MountingType.BothHand:
                    ap.transform.SetParent(m_bodyAvatar.GetMountingParent(MountingPoint.Left), false);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 载入模型,添加AvatarPart脚本
        /// </summary>
        /// <param name="apID"></param>
        /// <returns></returns>
        AvatarPart LoadAvatarPart(int apID) {
            AvatarPartRecord apr = AvatarDataHandler.GetAvatarPartRecord(apID);

            if (apr.id == -1) return null;

            GameObject prefab = Resources.Load<GameObject>(apr.path);

            if (prefab == null)
                throw new UnityException($"没有找到资源:{apr.path}");


            GameObject go = Instantiate<GameObject>(prefab);
            AvatarPart ap = go.AddComponent<AvatarPart>();
            ap.apr = apr;

            return ap;

        }


        // API

        public void SetAndBuildAvatar(string avatarTypeName, int apID) {
            SetAvatarID(avatarTypeName, apID);
            if (avatarTypeName == "MainBody")
                BuildAllAvatar();
            else
                BuildNormalAvatar(avatarTypeName);
        }

        //private void OnGUI() {
        //    if (GUI.Button(new Rect(300, 300, 300, 300), "按钮")) {
        //        SetAvatarID("MainBody", 0);
        //        SetAvatarID("Beard", 20002);
        //        SetAvatarID("Ears", 30002);
        //        SetAvatarID("Hair", 41002);
        //        SetAvatarID("Wing", 70074);
        //        SetAvatarID("Underwear", 122269);
        //        BuildAllAvatar();
        //    }


        //    if (GUI.Button(new Rect(600, 300, 300, 300), "按钮")) {
        //        SetAvatarID("Underwear", GetAvatarID("Underwear") + 1);
        //        BuildAllAvatar();
        //    }

        //}
    }
}
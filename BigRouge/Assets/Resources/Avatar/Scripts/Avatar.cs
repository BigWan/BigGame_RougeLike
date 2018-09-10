using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.Avatar {

    public class Avatar : MonoBehaviour {
        
        // key avatar enum
        // value avatarid
        Dictionary<string,int> m_allAvatarIDs;

        Dictionary<string, AvatarPart> m_allAvatarPart;

        AvatarBody m_body;

        int GetAvatarID(string apt) {
            if (m_allAvatarIDs.ContainsKey(apt))
                return m_allAvatarIDs[apt];
            else
                return -1;
        }

        public void SetAvatarID(string apt,int id) {
            if (m_allAvatarIDs.ContainsKey(apt))
                m_allAvatarIDs[apt] = id;
            else
                m_allAvatarIDs.Add(apt, id);
        }


        void SetAvatar(string apt, AvatarPart ap) {

            if (m_allAvatarPart.ContainsKey(apt)) {
                Destroy(m_allAvatarPart[apt].gameObject);
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
            foreach (var item in m_allAvatarIDs) {
                BuildNormalAvatar(item.Key);
            }
        }

        /// <summary>
        /// 组建非身体部件的Avatar
        /// </summary>
        /// <param name="avatarPartTypeName"></param>
        void BuildNormalAvatar(string avatarPartTypeName) {
            if (!m_allAvatarIDs.ContainsKey(avatarPartTypeName)) return;
            if (avatarPartTypeName == "MainBody") {
                return;
            }
            AvatarPart ap = LoadAvatarPartRes(m_allAvatarIDs[avatarPartTypeName]);
            MountAvatarPart(ap);
            SetAvatar(avatarPartTypeName, ap);
        }


        void BuildBody() {
            AvatarPart ap = LoadAvatarPartRes(m_allAvatarIDs["MainBody"]);
            MountAvatarPart(ap);
            m_body = ap.GetComponent<AvatarBody>();
            SetAvatar("MainBody", ap);
        }
         

        void MountAvatarPart(AvatarPart ap) {

            switch (ap.mountingType) {
                case MountingType.Root:
                    ap.transform.SetParent(transform);
                    break;
                case MountingType.Base:
                    ap.transform.SetParent(m_body.GetMountingParent(MountingPoint.Base),false);
                    break;
                case MountingType.Head:
                    ap.transform.SetParent(m_body.GetMountingParent(MountingPoint.Head),false);
                    break;
                case MountingType.Back:
                    ap.transform.SetParent(m_body.GetMountingParent(MountingPoint.Back),false);
                    break;
                case MountingType.Left:
                    ap.transform.SetParent(m_body.GetMountingParent(MountingPoint.Left),false);
                    break;
                case MountingType.Right:
                    ap.transform.SetParent(m_body.GetMountingParent(MountingPoint.Right),false);
                    break;
                case MountingType.BothHand:
                    ap.transform.SetParent(m_body.GetMountingParent(MountingPoint.Left),false);
                    break;
                default:
                    break;
            }
        }

        AvatarPart LoadAvatarPartRes(int apID) {
            AvatarPartRecord apr = AvatarDataHandler.GetAvatarPartRecord(apID);

            MountingType mp = AvatarDataHandler.GetMountingType(apr.avatarPartTypeName);

            if (apr.id == -1) return null;

            GameObject prefab = Resources.Load<GameObject>(apr.path);

            if (prefab == null) {
                throw new UnityException($"没有找到资源:{apr.path}");
            }

            GameObject go = Instantiate<GameObject>(prefab);
            AvatarPart ap = go.AddComponent<AvatarPart>();
            ap.apr = apr;

            return ap;

        }


        // API

        public void SetAndBuildAvatar(string avatarTypeName,int apID) {
            SetAvatarID(avatarTypeName, apID);
            if (avatarTypeName == "MainBody")
                BuildAllAvatar();
            else
                BuildNormalAvatar(avatarTypeName);
        }

        private void OnGUI() {
            if (GUI.Button(new Rect(300,300,300,300),"按钮")) {
                SetAvatarID("MainBody", 0);
                SetAvatarID("Beard", 20001);
                SetAvatarID("Ears", 30001);
                SetAvatarID("Hair", 41001);
                BuildAllAvatar();
            }


            if (GUI.Button(new Rect(600, 300, 300, 300), "按钮")) {
                SetAndBuildAvatar("MainBody", 1);
            }
            if (GUI.Button(new Rect(900, 300, 300, 300), "按钮")) {
                SetAndBuildAvatar("MainBody", 2);
            }
        }
    }
}
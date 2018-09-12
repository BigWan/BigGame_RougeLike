using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.Avatar {

    public enum AvatarSlot {
        MainBody = 0,
        Beard = 1,
        Ears = 2,
        Hair = 3,
        Face = 4,
        Horns = 5,
        Wing = 6,
        Bag = 7,
        MainHand = 101,
        OffHand = 102
    }
    public enum AvatarPartType {
        MainBody = 0,
        Beard = 1,
        Ears = 2,
        Hair = 3,
        Face = 4,
        Horns = 5,
        Wing = 6,
        Bag = 7,
        Weapon = 100
    }

    /// <summary>
    /// 挂载类型
    /// </summary>
    public enum MountingType {
        None = -1,
        Root = 0,
        Base = 1,
        Head = 2,
        Back = 3,
        LeftHand = 4,
        RightHand = 5,
        BothHand = 6,
    }

    /// <summary>
    /// 挂点位置枚举
    /// </summary>
    public enum MountingPoint {
        Root, Base, Head, Back, Left, Right
    }

    public enum SexType {
        None = 0,
        Female = 1,
        Male = 2,
        Other = 3,
    }

    public class Avatar : MonoBehaviour {

        // key avatar enum
        // value avatarid
        Dictionary<AvatarSlot, AvatarRecord> m_allAvatarRecords;

        Dictionary<AvatarSlot, AvatarPart> m_allAvatarPart;

        AvatarBody m_bodyAvatar;

        AvatarRecord GetAvatarRecord(AvatarSlot avSlot) {
            if (m_allAvatarRecords.ContainsKey(avSlot))
                return m_allAvatarRecords[avSlot];
            else
                return AvatarRecord.empty;
        }


        void SetAvatarRecord(AvatarSlot avSlot, int avID) {
            AvatarRecord record = AvatarDataHandler.GetAvatarRecord(avID);

            if (record.isEmpty()) {
                if (m_allAvatarRecords.ContainsKey(avSlot))
                    m_allAvatarRecords.Remove(avSlot);
                return;
            }
            m_allAvatarRecords[avSlot] = record;
        }


        void SetAvatarPart(AvatarSlot avSlot, AvatarPart ap) {
            if (m_allAvatarPart.ContainsKey(avSlot)) {
                Destroy(m_allAvatarPart[avSlot].gameObject);
            }
            m_allAvatarPart[avSlot] = ap;
        }

        AvatarPart GetAvatarPart(AvatarSlot avSlot) {
            if (m_allAvatarPart.ContainsKey(avSlot)) {
                return m_allAvatarPart[avSlot];
            }

            return null;
        }

        private void Awake() {
            m_allAvatarRecords = new Dictionary<AvatarSlot, AvatarRecord>();
        }

        /// <summary>
        /// 根据Avatar 部件信息,组建Avatar
        /// </summary>
        public void BuildAllAvatar() {
            BuildBody();
            //BuildBodyMat();
            foreach (var item in m_allAvatarRecords) {
                BuildAvatar(item.Key);
            }
        }

        /// <summary>
        /// 根据record 生成avatarpart
        /// </summary>
        /// <param name="avSlot"></param>
        void BuildAvatar(AvatarSlot avSlot) {
            if (m_bodyAvatar == null) return;
            if (!m_allAvatarRecords.ContainsKey(avSlot)) return;
            if (avSlot == AvatarSlot.MainBody) {
                return;
            }

            AvatarRecord avRecord = m_allAvatarRecords[avSlot];

            if (avRecord.isEmpty()) {
                if (m_allAvatarPart.ContainsKey(avSlot))
                    Destroy(m_allAvatarPart[avSlot].gameObject);
                return;
            }

            AvatarPart ap = LoadAvatarPart(avRecord);
            ap.mountPoint = GetMountingPoint(avSlot);

            ap.transform.SetParent(m_bodyAvatar.GetMountParent(ap.mountPoint),false);

            SetAvatarPart(avSlot, ap);
        }

        void BuildBody() {
            if (m_bodyAvatar != null)
                Destroy(m_bodyAvatar.gameObject);
            if (!m_allAvatarRecords.ContainsKey(AvatarSlot.MainBody))
                return;

            AvatarRecord avRecord = m_allAvatarRecords[AvatarSlot.MainBody];

            if (avRecord.isEmpty()) 
                return;
            
            AvatarPart ap = LoadAvatarPart(avRecord);
            ap.transform.SetParent(transform,false);

            SetAvatarPart(AvatarSlot.MainBody, ap);
            m_bodyAvatar = ap.gameObject.AddComponent<AvatarBody>();
        }

        MountingPoint GetMountingPoint(AvatarSlot avSlot) {
            switch (avSlot) {
                case AvatarSlot.MainBody:   return MountingPoint.Root;
                case AvatarSlot.Beard:  return MountingPoint.Head;
                case AvatarSlot.Ears:   return MountingPoint.Head;
                case AvatarSlot.Hair:   return MountingPoint.Head;
                case AvatarSlot.Face:   return MountingPoint.Head;
                case AvatarSlot.Horns:  return MountingPoint.Head;
                case AvatarSlot.Wing:   return MountingPoint.Back;
                case AvatarSlot.Bag:    return MountingPoint.Back;
                case AvatarSlot.MainHand:   return MountingPoint.Left;
                case AvatarSlot.OffHand:    return MountingPoint.Right;
                default:
                    throw new UnityException($"avSlot 不存在{avSlot}");
            }
        }





        /// <summary>
        /// 载入模型,添加AvatarPart脚本
        /// </summary>
        /// <param name="apID"></param>
        /// <returns></returns>
        AvatarPart LoadAvatarPart(AvatarRecord avRecord) {

            GameObject res = Resources.Load<GameObject>(avRecord.path);

            if (res == null)
                throw new UnityException($"没有找到资源:{avRecord.path}");


            GameObject go = Instantiate<GameObject>(res);

            AvatarPart ap = go.AddComponent<AvatarPart>();
            ap.avatarRecord = avRecord;

            return ap;
        }

        // API

        public void SetAndBuildAvatar(AvatarSlot avSlot, int apID) {
            SetAvatarRecord(avSlot, apID);
            if (avSlot == AvatarSlot.MainBody)
                BuildAllAvatar();
            else
                BuildAvatar(avSlot);
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
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
            SetAvatarRecord(avSlot, record);
        }

        void SetAvatarRecord(AvatarSlot avSlot,AvatarRecord avRecord) {
            if (avRecord.isEmpty()) {
                if (m_allAvatarRecords.ContainsKey(avSlot)) {                    
                    m_allAvatarRecords.Remove(avSlot);
                }
                if (m_allAvatarPart.ContainsKey(avSlot)) {
                    if (m_allAvatarPart[avSlot] != null)
                        Destroy(m_allAvatarPart[avSlot].gameObject);
                    m_allAvatarPart.Remove(avSlot);
                }
                return;
            }
            m_allAvatarRecords[avSlot] = avRecord;
        }


        void SetAvatarPart(AvatarSlot avSlot, AvatarPart ap) {
            if (m_allAvatarPart.ContainsKey(avSlot)) {
                if(m_allAvatarPart[avSlot]!=null)
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
            m_allAvatarPart = new Dictionary<AvatarSlot, AvatarPart>();
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
            if(avSlot == AvatarSlot.OffHand && avRecord.mountingType == MountingType.BothHand) {
                ap.transform.localEulerAngles += new Vector3(0, 180, 0);
            }
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
                case AvatarSlot.MainHand:   return MountingPoint.Right;
                case AvatarSlot.OffHand:    return MountingPoint.Left;
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

            GameObject res = Resources.Load<GameObject>("Avatar/AvatarParts/" + avRecord.path);

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


        public void SaveData() {
            PlayerPrefs.SetInt("Avatar_MainBody_ID", GetAvatarRecord(AvatarSlot.MainBody).id);
            PlayerPrefs.SetInt("Avatar_Beard_ID", GetAvatarRecord(AvatarSlot.Beard).id);
            PlayerPrefs.SetInt("Avatar_Hair_ID", GetAvatarRecord(AvatarSlot.Hair).id);
            PlayerPrefs.SetInt("Avatar_Ears_ID", GetAvatarRecord(AvatarSlot.Ears).id);
            PlayerPrefs.SetInt("Avatar_Face_ID", GetAvatarRecord(AvatarSlot.Face).id);
            PlayerPrefs.SetInt("Avatar_Horns_ID", GetAvatarRecord(AvatarSlot.Horns).id);
            PlayerPrefs.SetInt("Avatar_Wing_ID", GetAvatarRecord(AvatarSlot.Wing).id);
            PlayerPrefs.SetInt("Avatar_Bag_ID", GetAvatarRecord(AvatarSlot.Bag).id);
            PlayerPrefs.SetInt("Avatar_MainHand_ID", GetAvatarRecord(AvatarSlot.MainHand).id);
            PlayerPrefs.SetInt("Avatar_OffHand_ID", GetAvatarRecord(AvatarSlot.OffHand).id);

        }

        public void ReadData() {
            SetAvatarRecord(AvatarSlot.MainBody, PlayerPrefs.GetInt("Avatar_MainBody_ID"));
            SetAvatarRecord(AvatarSlot.Beard, PlayerPrefs.GetInt("Avatar_Beard_ID"));
            SetAvatarRecord(AvatarSlot.Hair, PlayerPrefs.GetInt("Avatar_Hair_ID"));
            SetAvatarRecord(AvatarSlot.Ears, PlayerPrefs.GetInt("Avatar_Ears_ID"));
            SetAvatarRecord(AvatarSlot.Face, PlayerPrefs.GetInt("Avatar_Face_ID"));
            SetAvatarRecord(AvatarSlot.Horns, PlayerPrefs.GetInt("Avatar_Horns_ID"));
            SetAvatarRecord(AvatarSlot.Wing, PlayerPrefs.GetInt("Avatar_Wing_ID"));
            SetAvatarRecord(AvatarSlot.Bag, PlayerPrefs.GetInt("Avatar_Bag_ID"));
            SetAvatarRecord(AvatarSlot.MainHand, PlayerPrefs.GetInt("Avatar_MainHand_ID"));
            SetAvatarRecord(AvatarSlot.OffHand, PlayerPrefs.GetInt("Avatar_OffHand_ID"));
            BuildAllAvatar();
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
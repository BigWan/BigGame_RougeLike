using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.Avatar {

    public class Avatar : MonoBehaviour {

        [Header ("身体部分")]

        // 身体
        public int m_avatarPartBodyID;
        public BodyAvatar avatarPartBody;


        public int m_bodyMatId;
        public Material bodyMat;

        // public int m_sexId;

        // public int m_skinColorId;

        // public int m_skinPictureId;

        // public int m_skinPictureColorId;

        [Header ("头部")]

        // 胡子

        public int m_beardMeshId;
        public int m_beardMatId;

        // public int m_beardColorId;

        // 耳朵

        public int m_earsMeshId;
        public int m_earsMatId;

        // public int m_earPictureId;

        // 角

        public int m_hornsMeshId;
        public int m_hornsMatId;
        // public int m_hornsPictureId;

        // 装备部分

        public int m_headEquipId; // 皇冠,帽子,头巾,头盔,面具

        public int m_bagEquipId; // 背包,麻袋,背篮

        public int m_wingEquipId; // 翅膀,神器

        public int m_jacketId;

        public int m_weaponId;

        /// <summary>
        /// 设置默认值
        /// </summary>
        public void SetDefault () {

        }

        /// <summary>
        /// 根据数据生成模型
        /// </summary>
        public void Create () {

        }

        private void Awake () {
            avatarPartBody = AvatarDataUtil.GetAvatarPartBody(m_avatarPartBodyID);
            BodyAvatar bodyGo = Instantiate<BodyAvatar>(avatarPartBody);
            bodyGo.transform.SetParent(transform);

            bodyGo.bodyMaterial = bodyMat;
        }

        private void OnGUI() {
            if(GUI.Button(new Rect(50, 50, 50, 50), "ChangeBody")) {
                m_avatarPartBodyID = 2;
            }
        }
    }
}
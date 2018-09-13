using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Avatar = BigRogue.CharacterAvatar.Avatar;


namespace BigRogue.Player {

    /// <summary>
    /// 玩家类
    /// </summary>
    [RequireComponent(typeof(Avatar))]
    public class Player:MonoBehaviour  {

        private Animator m_animator {
            get {
                if(m_avatar == null) {
                    return null;
                } else {
                    return m_avatar.bodyAvatar.GetComponent<Animator>();
                }
            }
        }

        private Avatar m_avatar;

        private void Awake() {
            m_avatar = GetComponent<Avatar>();
            
        }

        void SetAvatarInfo() {
            
        }

        private void Update() {
            
        }

    }
}

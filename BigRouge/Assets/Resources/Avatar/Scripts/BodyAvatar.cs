using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.Avatar {

    public class BodyAvatar : MonoBehaviour {

        [Header("Mount Points")]
        public Transform basePoint;
        public Transform headPoint;
        public Transform backPoint;
        public Transform leftPoint;
        public Transform rightPoint;

        [Header("Components Refs")]
        // 身体的材质球
        public SkinnedMeshRenderer m_bodyMeshRenderer;


        public Material bodyMaterial {
            get {
                return m_bodyMeshRenderer.material;
            }
            set {
                m_bodyMeshRenderer.material = value;
            }
        }








    }
}
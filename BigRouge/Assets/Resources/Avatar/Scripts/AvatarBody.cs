using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.Avatar {

    /// <summary>
    /// 挂载类型
    /// </summary>
    public enum MountingType {
        None = -1,
        Root = 0,
        Base = 1,
        Head = 2,
        Back = 3,
        Left = 4,
        Right = 5,
        BothHand = 6,
    }

    public enum MountingPoint {
        Base, Head, Back, Left, Right
    }

    public enum SexType {
        None = 0,
        Female = 1,
        Male = 2,
    }

    /// <summary>
    /// 组
    /// </summary>
    public class AvatarBody : MonoBehaviour {

        [Header("Mount Points")]
        public Transform headPoint;
        public Transform backPoint;
        public Transform leftPoint;
        public Transform rightPoint;

        [Header("Components Refs")]
        // 身体的材质球
        private SkinnedMeshRenderer m_bodyMeshRenderer;

        public Transform GetMountingParent(MountingPoint pointType) {
            switch (pointType) {
                case MountingPoint.Base:return transform;
                case MountingPoint.Head:return headPoint;
                case MountingPoint.Back:return backPoint;
                case MountingPoint.Left:return leftPoint;
                case MountingPoint.Right:return rightPoint;
                default:
                    throw new UnityException($"挂点类型错误,没有这样的点{pointType.ToString()}");
            }
        }

        private void Awake() {
            m_bodyMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        }

        public void SetBodyMaterial(Material mat) {
            m_bodyMeshRenderer.material = mat;
        }









    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.CharacterAvatar {


    /// <summary>
    /// 组
    /// </summary>
    public class AvatarBody : MonoBehaviour {






        private Transform rootPoint;
        private Transform headPoint;
        private Transform backPoint;
        private Transform leftPoint;
        private Transform rightPoint;





        public Transform GetMountParent(MountingPoint pointType) {
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
            headPoint = transform.Find("RigPelvis/RigSpine1/RigSpine2/RigRibcage/RigNeck/RigHead/Dummy Prop Head");
            backPoint = transform.Find("RigPelvis/RigSpine1/RigSpine2/RigRibcage/Dummy Prop Back");
            leftPoint = transform.Find("RigPelvis/RigSpine1/RigSpine2/RigRibcage/RigLArm1/RigLArm2/RigLArmPalm/Dummy Prop Left");
            rightPoint = transform.Find("RigPelvis/RigSpine1/RigSpine2/RigRibcage/RigRArm1/RigRArm2/RigRArmPalm/Dummy Prop Right");
            rootPoint = transform.parent;
        }



    }
}
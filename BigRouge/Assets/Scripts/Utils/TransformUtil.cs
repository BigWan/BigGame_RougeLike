using UnityEngine;
using System.Collections;

public static class TransformUtil { 


    public static void SetLocalPositionX(this Transform trans,float x) {
        trans.localPosition = new Vector3(x, trans.localPosition.y, trans.localPosition.z);
    }
    public static void SetLocalPositionY(this Transform trans, float y) {
        trans.localPosition = new Vector3(trans.localPosition.x, y, trans.localPosition.z);
    }
    public static void SetLocalPositionZ(this Transform trans, float z) {
        trans.localPosition = new Vector3(trans.localPosition.x, trans.localPosition.y,z);
    }

}

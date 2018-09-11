using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarRotate : MonoBehaviour {



    public void AddDegree() {
        transform.Rotate(new Vector3(0, 10, 0));
    }
    public void SubDegree() {
        transform.Rotate(new Vector3(0, -10, 0));
    }
}

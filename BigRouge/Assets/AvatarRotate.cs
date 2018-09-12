using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarRotate : MonoBehaviour {



    public void AddDegree() {
        transform.Rotate(new Vector3(0, 1, 0));
    }
    public void SubDegree() {
        transform.Rotate(new Vector3(0, -1, 0));
    }


    private void Update() {
        if (Input.GetKey(KeyCode.A)) {
            AddDegree();
        }
        if (Input.GetKey(KeyCode.D)) {
            SubDegree();
        }
    }

}

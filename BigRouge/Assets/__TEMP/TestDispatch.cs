using System;
using System.Collections;
using System.Collections.Generic;
using BigRogue;
using UnityEditor;
using UnityEngine;

public class TestDispatch : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        BigRogue.MessageDispatch.AddListener(MessageCode.MoveButtonClick,OnCLick);
    }

    private void OnCLick(object sender, Message content) {
        Debug.Log((content.messageID));
        Debug.Log("woshoudao zhege xiaoxi");
    }


    void OnGUI() {
        if (GUI.Button(new Rect(10, 10, 100, 100), "abadf")) {
            MessageDispatch.SendMessage(this,new Message(MessageCode.MoveButtonClick));
        }

    }


    
    void Update() {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigRogue.Avatar;
using System.Linq;


public class Test : MonoBehaviour {
    public List<string> nullNames;
	// Use this for initialization
	void Start () {




        //list =  AvatarDataHandler.CheckResourcesValidity().Values.ToList<GameObject>();
        //name =  AvatarDataHandler.CheckResourcesValidity().Keys.ToList<string>();

        //nullNames = AvatarDataHandler.GetNullResources();

        GameObject go =  Resources.Load<GameObject>("Avatar/AvatarParts/Bodys/AvatarBodyNormal");

        //Instantiate<GameObject>(go);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointedWall : MonoBehaviour {
    List<Transform> children = new List<Transform>();
	// use this for initialization
	void Start () {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform t = transform.GetChild(i);
        }


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

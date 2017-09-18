using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {
    public Vector3 origin;
    public float radius = 1f;
    public float speed = 1f;
    public bool isOrbiting;
    public bool lookAtFixedPoint = false;
    public Transform fixedTarget;

	// Use this for initialization
	void Start ()
	{
	    QualitySettings.vSyncCount = 0;
        origin = transform.position;
        
	}
	
	// Update is called once per frame
	void Update () {
        if(isOrbiting)
            transform.position = Vector3.Lerp(transform.position, origin + new Vector3(Mathf.Sin(Time.time * speed) * radius, 0, Mathf.Cos(Time.time * speed) * radius), 0.5f);
        
        if(lookAtFixedPoint)
        {
            Quaternion target = Quaternion.LookRotation(fixedTarget.position-transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, .5F);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointedWall : MonoBehaviour {
    List<Transform> children = new List<Transform>();

    public float breakForce = 50f;
    public float breakTourque = 50f;
	// use this for initialization
	void Start () {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform t = transform.GetChild(i);
            RaycastHit hit;
            //Check for nearby connected objects
            if (Physics.Raycast(t.position, t.up, out hit, t.GetComponent<Collider>().bounds.extents.y+0.1f))
            {
                if (hit.collider.CompareTag("Physics Object"))
                {
                    FixedJoint joint = t.gameObject.AddComponent<FixedJoint>();
                    joint.connectedBody = hit.rigidbody;
                    joint.breakForce = breakForce;
                    joint.breakTorque = breakTourque;
                    joint.enableCollision = true;
                }
            }
            if (Physics.Raycast(t.position, -t.up, out hit, t.GetComponent<Collider>().bounds.extents.y + 0.1f))
            {
                if (hit.collider.CompareTag("Physics Object"))
                {
                    FixedJoint joint = t.gameObject.AddComponent<FixedJoint>();
                    joint.connectedBody = hit.rigidbody;
                    joint.breakForce = breakForce;
                    joint.breakTorque = breakTourque;
                    joint.enableCollision = true;
                }
            }
            if (Physics.Raycast(t.position, t.right, out hit, t.GetComponent<Collider>().bounds.extents.x + 0.1f))
            {
                if (hit.collider.CompareTag("Physics Object"))
                {
                    FixedJoint joint = t.gameObject.AddComponent<FixedJoint>();
                    joint.connectedBody = hit.rigidbody;
                    joint.breakForce = breakForce;
                    joint.breakTorque = breakTourque;
                    joint.enableCollision = true;
                }
            }
            if (Physics.Raycast(t.position, -t.right, out hit, t.GetComponent<Collider>().bounds.extents.x + 0.1f))
            {
                if (hit.collider.CompareTag("Physics Object"))
                {
                    FixedJoint joint = t.gameObject.AddComponent<FixedJoint>();
                    joint.connectedBody = hit.rigidbody;
                    joint.breakForce = breakForce;
                    joint.breakTorque = breakTourque;
                    joint.enableCollision = true;
                }
            }
        }


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

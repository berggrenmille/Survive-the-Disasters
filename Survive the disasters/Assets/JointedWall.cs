using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointedWall : MonoBehaviour {
    public float minBreakForce = 50f;
    public float maxBreakForce = 50f;
    public float minBreakTourque = 50f;
    public float maxBreakTourque = 50f;
        // use this for initialization
        private void Start () {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform t = transform.GetChild(i);
            RaycastHit hit;
            //Connect to nearby objects
            if (Physics.Raycast(t.position, t.up, out hit, t.GetComponent<Collider>().bounds.extents.y+0.1f))
            {
                
                if (hit.collider.gameObject.FindComponentInChildWithTag<Transform>("Jointed"))
                {
                    FixedJoint joint = t.gameObject.AddComponent<FixedJoint>();
                    joint.connectedBody = hit.rigidbody;
                    joint.breakForce = Random.Range(minBreakForce, maxBreakForce);
                    joint.breakTorque = Random.Range(minBreakTourque, maxBreakTourque);
                    joint.enableCollision = true;
                }
            }
            if (Physics.Raycast(t.position, -t.up, out hit, t.GetComponent<Collider>().bounds.extents.y + 0.1f))
            {
                if (hit.collider.gameObject.FindComponentInChildWithTag<Transform>("Jointed"))
                {
                    FixedJoint joint = t.gameObject.AddComponent<FixedJoint>();
                    joint.connectedBody = hit.rigidbody;
                    joint.breakForce = Random.Range(minBreakForce, maxBreakForce);
                    joint.breakTorque = Random.Range(minBreakTourque, maxBreakTourque);
                    joint.enableCollision = true;
                }
            }
            if (Physics.Raycast(t.position, t.right, out hit, t.GetComponent<Collider>().bounds.extents.x + 0.1f))
            {
                if (hit.collider.gameObject.FindComponentInChildWithTag<Transform>("Jointed"))
                {
                    FixedJoint joint = t.gameObject.AddComponent<FixedJoint>();
                    joint.connectedBody = hit.rigidbody;
                    joint.breakForce = Random.Range(minBreakForce, maxBreakForce);
                    joint.breakTorque = Random.Range(minBreakTourque, maxBreakTourque);
                    joint.enableCollision = true;
                }
            }
            if (Physics.Raycast(t.position, -t.right, out hit, t.GetComponent<Collider>().bounds.extents.x + 0.1f))
            {
                if (hit.collider.gameObject.FindComponentInChildWithTag<Transform>("Jointed"))
                {
                    FixedJoint joint = t.gameObject.AddComponent<FixedJoint>();
                    joint.connectedBody = hit.rigidbody;
                    joint.breakForce = Random.Range(minBreakForce, maxBreakForce);
                    joint.breakTorque = Random.Range(minBreakTourque, maxBreakTourque);
                    joint.enableCollision = true;
                }
            }
            if (Physics.Raycast(t.position, t.forward, out hit, t.GetComponent<Collider>().bounds.extents.x + 0.1f))
            {
                if (hit.collider.gameObject.FindComponentInChildWithTag<Transform>("Jointed"))
                {
                    FixedJoint joint = t.gameObject.AddComponent<FixedJoint>();
                    joint.connectedBody = hit.rigidbody;
                    joint.breakForce = Random.Range(minBreakForce, maxBreakForce);
                    joint.breakTorque = Random.Range(minBreakTourque, maxBreakTourque);
                    joint.enableCollision = true;
                }
            }
            if (Physics.Raycast(t.position, -t.forward, out hit, t.GetComponent<Collider>().bounds.extents.x + 0.1f))
            {
                if (hit.collider.gameObject.FindComponentInChildWithTag<Transform>("Jointed"))

                {
                    FixedJoint joint = t.gameObject.AddComponent<FixedJoint>();
                    joint.connectedBody = hit.rigidbody;
                    joint.breakForce = Random.Range(minBreakForce, maxBreakForce);
                    joint.breakTorque = Random.Range(minBreakTourque, maxBreakTourque);
                    joint.enableCollision = true;
                }
            }
        }


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointedWall : MonoBehaviour {
    List<Transform> children = new List<Transform>();

    public float breakForce = 50f;
    public float breakTourque = 50f;

    public bool useRandomBreakOffset;
    public float breakForceOffset = 20f;
    public float breakTourqueOffset = 20f;

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
                    AddJoint(t.gameObject, hit.rigidbody);
                }
            }
            if (Physics.Raycast(t.position, -t.up, out hit, t.GetComponent<Collider>().bounds.extents.y + 0.1f))
            {
                if (hit.collider.CompareTag("Physics Object"))
                {
                    AddJoint(t.gameObject, hit.rigidbody);
                }
            }
            if (Physics.Raycast(t.position, t.right, out hit, t.GetComponent<Collider>().bounds.extents.x + 0.1f))
            {
                if (hit.collider.CompareTag("Physics Object"))
                {
                    AddJoint(t.gameObject, hit.rigidbody);
                }
            }
            if (Physics.Raycast(t.position, -t.right, out hit, t.GetComponent<Collider>().bounds.extents.x + 0.1f))
            {
                if (hit.collider.CompareTag("Physics Object"))
                {
                    AddJoint(t.gameObject, hit.rigidbody);
                }
            }
        }


	}

    private void AddJoint(GameObject origin, Rigidbody target)
    {
        FixedJoint joint = origin.AddComponent<FixedJoint>();
        joint.connectedBody = target;
        joint.enableCollision = true;
        if (useRandomBreakOffset)
        {
            joint.breakForce = breakForce + Random.Range(-breakForceOffset,breakForceOffset);
            joint.breakTorque = breakTourque + Random.Range(-breakTourqueOffset,breakTourqueOffset);
        }
        else
        {
            joint.breakForce = breakForce;
            joint.breakTorque = breakTourque;
        }
    }
}

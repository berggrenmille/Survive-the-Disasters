using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour {
    public Rigidbody rb;
    public const float G = 6.62f;
    public float Gfactor = 0.01f;

    public bool randomVelocity = true;

    public Vector3 initVel = Vector3.zero;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        if (randomVelocity)
            rb.velocity = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20));
        else
            rb.velocity = initVel;
	}
	// f = g * (m1 * m2)/r*r
    //g = 6.67E-11
	// Update is called once per frame
	void FixedUpdate () {
        Attractor[] attractors = FindObjectsOfType<Attractor>();
        foreach(Attractor a in attractors)
        {
            if (a != this)
            {
                rb.AddForce((a.transform.position - transform.position) * G * Gfactor * ((rb.mass * a.rb.mass) / Mathf.Pow((a.transform.position - transform.position).magnitude, 2)));
            }
        }
	}
}

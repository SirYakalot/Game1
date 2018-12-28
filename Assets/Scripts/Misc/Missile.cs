using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    Vector3 velocity = new Vector3();
    float speed = 8.0f;
    float maxRads;

	// Use this for initialization
	void Start () {
        velocity = Vector3.up;
        maxRads = Mathf.Deg2Rad * 10.0f * speed;
	}
	
	// Update is called once per frame
	void Update () {


        Vector3 toTarget = (Globals.Player.transform.position - transform.position).normalized;
        
        velocity = Vector3.RotateTowards(velocity, toTarget, maxRads * Time.deltaTime, 0.0f);

        transform.position += velocity * Time.deltaTime * speed;
        transform.rotation = Quaternion.LookRotation(velocity);
	}

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}

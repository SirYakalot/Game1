using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {

    public Transform rocket;

    // Use this for initialization
    void Start () {
        Transform rocketClone = (Transform)Instantiate(rocket, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update() {

    }

    //need to turn this into a coroutine friendly function - so you can wait 5, then wait-until (on-collision
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(collision.gameObject);
        }
        // Debug-draw all contact points and normals
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
    }
}

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
    void Update () {
		
	}
}

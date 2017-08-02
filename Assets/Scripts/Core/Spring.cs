using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    private Vector3 springAnchor = new Vector3();
    private Vector3 prevPos;
    private float speed = 0.0f;

    public float strength = 1.0f;
    public float mass = 1.0f;
    public float damping = 1.0f;

    private void Start()
    {
        prevPos = transform.position;
    }

    private void Update()
    {
        float velocity = (transform.position - prevPos).x;
        print(velocity);
        prevPos = transform.position;
        speed = ScriptFuncs.SpringObjectLinear(speed, springAnchor, this.gameObject, strength, mass, damping, velocity);

        transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y, transform.position.z);
    }
}

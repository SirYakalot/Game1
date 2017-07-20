using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringCamera : MonoBehaviour
{
    private Vector3 thisThing = new Vector3();
    public float strength = 0.0f;
    public float mass = 0.0f;
    public float speed = 0.0f;

    private void Update()
    {
        speed = ScriptFuncs.SpringObjectLinear(speed, thisThing, this.gameObject, strength, mass);

        transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y, transform.position.z);
    }
}

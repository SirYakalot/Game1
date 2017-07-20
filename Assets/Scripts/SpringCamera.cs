using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringCamera : MonoBehaviour
{
    private Vector3 thisThing = new Vector3();
    public float strength = 0.0f;
    public float mass = 0.0f;

    private void Update()
    {
        ScriptFuncs.SpringObjectLinear(thisThing, this.gameObject, strength, mass);
    }
}

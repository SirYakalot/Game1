using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot {
    public Vector3 _position;
    // public List<Dot> adjacentDots = new List<Dot>();
    private Dot parentDot = null;
    public Dot (Vector3 position)
    {
        _position = position;
    }

    public Dot (Vector3 position, Dot parentDot)
    {
        _position = position;
        this.parentDot = parentDot;
    }

    public void Update ()
    {
        if (parentDot != null)
        {
            Debug.DrawLine(parentDot._position, _position);
        }
    }
}

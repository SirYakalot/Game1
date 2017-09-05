﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCharacter : MonoBehaviour {

    private int gridX;
    private int gridZ;

	// Use this for initialization
	void Start () {
        gridX = (int)transform.position.x;
        gridZ = (int)transform.position.z;

        float halfScale = transform.localScale.y * 0.5f; 
        transform.position = new Vector3(gridX, halfScale, gridZ);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCharacter : MonoBehaviour {

    public int gridX;
    public int gridZ;

    public int gridInfluence = 3;

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

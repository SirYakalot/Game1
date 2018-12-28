using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCharacter : MonoBehaviour {

    public int gridX;
    public int gridZ;

    public int gridInfluence = 3;
    public int health = -1;
    public int Health { get; set; }
    public int maxHealth = -1;
    private int attack = -1;
    public int Attack { get; set; }
    public int maxAttack = -1;
    private bool usedThisTurn = false;
    // -1 is ai control
    public int teamIndex = -1;
    public bool UsedThisTurn { get; set; }

    public Card testAbility = null;

	// Use this for initialization
	void Start () {
        gridX = (int)transform.position.x;
        gridZ = (int)transform.position.z;

        health = maxHealth;
        attack = maxAttack;

        float halfScale = transform.localScale.y * 0.5f; 
        transform.position = new Vector3(gridX, halfScale, gridZ);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

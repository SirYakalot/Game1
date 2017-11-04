using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//holds the info that you can query
public class NPC : MonoBehaviour {

    //relationship data is very systemic, with default reactions, but these get overridden in each character. so you 'script' the individual lines, but they will react to hating multiple characters in the same way 
    private List<relationshipData> relationships;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

//contains relationship data for ONE character 
public struct relationshipData
{
    //allow both
    private bool like;
    private bool hate;
}
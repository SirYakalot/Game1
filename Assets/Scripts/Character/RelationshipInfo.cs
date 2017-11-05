using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//holds the info that you can query
[ExecuteInEditMode]
public class RelationshipInfo : MonoBehaviour {

    //relationship data is very systemic, with default reactions, but these get overridden in each character. so you 'script' the individual lines, but they will react to hating multiple characters in the same way 
    public List<RelationshipData> relationships;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        npc[] allNPCs = FindObjectsOfType(typeof(npc)) as npc[];
        //compare the difference and remove / add accordingly
        foreach(npc character in allNPCs)
        {
            relationships.Add(new RelationshipData());
        }
    }
}
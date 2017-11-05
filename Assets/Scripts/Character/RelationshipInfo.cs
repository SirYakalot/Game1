using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//holds the info that you can query
[ExecuteInEditMode]
public class RelationshipInfo : MonoBehaviour {

    //relationship data is very systemic, with default reactions, but these get overridden in each character. so you 'script' the individual lines, but they will react to hating multiple characters in the same way 
    
    public List<npc> relationshipKeys;
    public List<RelationshipData> relationshipValues;

    // Update is called once per frame
    void Update () {
        if (relationshipKeys == null) { relationshipKeys = new List<npc>(); }
        if (relationshipValues == null) { relationshipValues = new List<RelationshipData>(); }

        List<npc> allNPCs = new List<npc>();
        allNPCs.AddRange(FindObjectsOfType(typeof(npc)) as npc[]);

        List<npc> currentKeys = new List<npc>(relationshipKeys);
        foreach (npc character in currentKeys)
        {
            if (!allNPCs.Contains(character))
            {
                relationshipValues.RemoveAt(relationshipKeys.IndexOf(character));
                relationshipKeys.Remove(character);
            }
        }

        foreach (npc character in allNPCs)
        {
            if (!relationshipKeys.Contains(character))
            {
                relationshipKeys.Add(character);
                relationshipValues.Add(new RelationshipData(character.name));
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//contains relationship data for ONE character 
[System.Serializable]
public class RelationshipData
{
    public string name;
    //allow both
    public bool like;
    public bool hate;

    public RelationshipData(string name)
    {
        this.name = name;
    }
}
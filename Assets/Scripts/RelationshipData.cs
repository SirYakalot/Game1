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
    
    // these lines should ultimately come from the npc - so, they each have a hate line, a like line etc. differences. 
    // what if the sentence is somehow composed of that, and some sescriptive words found in the target NPC, just to provide enough randomness to not be repetitive. in a way 'person' should be in the target. - don't have to worry about having 'types', each npc decribes who they are. 

    public string Like
    {
        get { return like ? "I really like them." : "I don't like them."; }
    }

    public string Hate
    {
        get { return hate ? "I fuckin' hate that person." : "No, I don't mind that person."; }
    }

    public RelationshipData(string name)
    {
        this.name = name;
    }
}
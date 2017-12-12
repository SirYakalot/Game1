using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals
{
	private static List<npc> allNpcs = new List<npc>();

	private static GameObject player = null;

    public static GameObject Player
    {
        get
        {
            return (player == null) ? GameObject.Find("player") : Globals.player;
        }
    }
    // I DON'T THINK WE EVEN NEED THE VARS, JUST WRAP A LOOKUP FUNC - ALSO, PROBABLY JUST PUT THIS IN SCRIPFUNCS    
    public static GameObject AllNpcs
    {
        get
        {
            return (player == null) ? GameObject.Find("player") : Globals.player;
        }
    }
}

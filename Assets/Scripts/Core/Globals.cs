using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DEPRICATED
public class Globals
{
    // All NPC's are resposible for adding themselves to this global list
	public static List<npc> allNpcs = new List<npc>();

	private static GameObject player = null;

    public static GameObject Player
    {
        get
        {
            if (player == null)
            {
                player = GameObject.Find("Player");
                return player;
            }
            else
            {
                return Globals.player;
            }
        }
    }
}

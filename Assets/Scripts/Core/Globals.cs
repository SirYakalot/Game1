using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals
{
	public static List<npc> allNpcs = new List<npc>();

	private static GameObject player = null;

	public static GameObject Player
	{
		get
		{
			return (player == null) ? GameObject.Find("player") : Globals.player;
		}
	}
}

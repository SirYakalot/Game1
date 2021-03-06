﻿using UnityEngine;
using UnityEngine.AI;

public static class ScriptFuncs
{
    // Maths----------------------------------

    public static float LerpScale(float lowIn, float highIn, float lowOut, float highOut, float t)
	{
		return Mathf.Lerp (lowOut, highOut, Mathf.InverseLerp (lowIn, highIn, t));//test this
	}

    //this should extend Vector3
    public static Vector3 FlattenY(Vector3 vector)
    {
        return new Vector3(vector.x, 0.0f, vector.z);
    }

    public static float Spring(float xDistFromRest, float kStrength, float cDamping, float velocity)
    {
        return -kStrength * xDistFromRest - cDamping * velocity;
    }

    public static float SpringObjectLinear(float speed, Vector3 springOrigin, GameObject obj, float kStrength, float mass, float damping, float velocity)
    {
        // mass to work out acceleration, then apply delta time to that.  
        float distFromRest = obj.transform.position.x - springOrigin.x;
        float f = Spring(distFromRest, kStrength, damping, velocity);


        //this needs to calculate momentum
        float acceleration = f / mass;



        return (speed + acceleration);
    }

    // AI stuff------------------------------
		
    //need to find a way of making sure this is ready on the first frame?
	public static npc GetNearestNpc()
	{
		npc closestNpc = null;
		float distanceToNearestNpc = 99999.9f;


		//work out the closest npc and 
		foreach (npc thisNpc in Globals.allNpcs)
		{
			float distanceToCurrentNpc = Vector3.Distance(Globals.Player.transform.position, thisNpc.transform.position);
			if ( distanceToCurrentNpc < distanceToNearestNpc )
			{
				closestNpc = thisNpc;
				distanceToNearestNpc = distanceToCurrentNpc;
			}
		}
		return closestNpc;
	}

    public static bool AgentReachedDestination(NavMeshAgent agent)
    {
        return !agent.pathPending && agent.remainingDistance < (0.5f + agent.stoppingDistance);
    }
}

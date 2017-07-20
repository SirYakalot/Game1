using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public static float Spring(float xDistFromRest, float kStrength)
    {
        float fForce = -kStrength * xDistFromRest;
        return fForce;
    }

    public static float SpringObjectLinear(float speed, Vector3 springOrigin, GameObject obj, float kStrength, float mass)
    {
        // / mass to work out acceleration, then apply delta time to that.  
        float distFromRest = obj.transform.position.x - springOrigin.x;
        float f = Spring(distFromRest, kStrength);


        //this needs to calculate momentum
        float acceleration = f / mass;



        return (speed + acceleration);// * Time.deltaTime;
    }

    // AI stuff------------------------------
		
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
}

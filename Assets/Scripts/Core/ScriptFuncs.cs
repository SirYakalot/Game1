using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScriptFuncs
{
	public static float LerpScale(float lowIn, float highIn, float lowOut, float highOut, float t)
	{
		return Mathf.Lerp (lowOut, highOut, Mathf.InverseLerp (lowIn, highIn, t));//test this
	}
}

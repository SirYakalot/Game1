using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
    public abstract class PivotBasedCameraRig1 : AbstractTargetFollower
    {
        // This script is designed to be placed on the root object of a camera rig,
        // comprising 3 gameobjects, each parented to the next:

        // 	Camera Rig
        // 		Pivot
        // 			Camera

        protected Transform m_Tripod; // the transform of the camera
        protected Transform m_Pivot; // the point at which the camera pivots around
        protected Vector3 m_LastTargetPosition;


        protected virtual void Awake()
        {
            // find the camera in the object hierarchy
            m_Tripod = GetComponentInChildren<Tripod>().transform;
            m_Pivot = m_Tripod.parent;
        }
    }
}

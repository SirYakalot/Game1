using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class Tripod : MonoBehaviour {

    private Vector3 m_LocalPos;
    [SerializeField] private float m_MoveSpeed;

    //todo should this own a reference to the rig? or should you set the tripod on the rig?

	// Use this for initialization
	void Start ()//todo should this be awake?
    {
        m_LocalPos = transform.localPosition;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //  TODO this is the base tripod class, the lerpy one should eventually be a subtype of tripod
        transform.position = Vector3.Lerp(transform.position, transform.parent.position, Time.deltaTime * m_MoveSpeed);
    }
}

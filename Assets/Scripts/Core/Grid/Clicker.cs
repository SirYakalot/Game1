using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour {

    private Collider thingClicked;

    // Use this for initialization
    void Start () {
		
	}
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == "Plane")
                {
                    print(hit.point.x + " " + hit.point.z);
                   
                    print(Mathf.RoundToInt(hit.point.x) + " " + Mathf.RoundToInt(hit.point.z));

                    if (thingClicked != null)
                    {
                        // localScale should be stored in the grid char and accessed. 
                        thingClicked.transform.position = new Vector3(Mathf.RoundToInt(hit.point.x), thingClicked.transform.localScale.y * 0.5f, Mathf.RoundToInt(hit.point.z));
                        thingClicked = null;
                    }
                }
                else
                {
                    print(hit.collider.name);
                    thingClicked = hit.collider;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : StateScript {

    private Collider thingClicked = null;

    // Use this for initialization
    void Start () {
		Go(NothingSelectedStart());
	}
    
    private IEnumerator NothingSelectedStart()
    {
        yield return new WaitUntil(() => Input.GetButtonDown("Fire1"));

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider.name != "Plane")//really replace this with some tag check
        {
            print(hit.collider.name);
            thingClicked = hit.collider;
            Go(PlaceObjectStart());
        }

        // if nothing was selected, restart the state
        Go(NothingSelectedStart());
    }

    private IEnumerator PlaceObjectStart()
    {
        yield return new WaitUntil(() => Input.GetButtonDown("Fire1"));

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider.name == "Plane")
        {
            
            print(hit.point.x + " " + hit.point.z);
            
            print(Mathf.RoundToInt(hit.point.x) + " " + Mathf.RoundToInt(hit.point.z));

            // move the object

            // localScale should be stored in the grid char and accessed. 
            thingClicked.transform.position = new Vector3(Mathf.RoundToInt(hit.point.x), thingClicked.transform.localScale.y * 0.5f, Mathf.RoundToInt(hit.point.z));
            thingClicked = null;
            Go(NothingSelectedStart());
        }

        // if nothing was selected, restart the state
        Go(PlaceObjectStart());
    }
}
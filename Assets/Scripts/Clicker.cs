﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : StateScript {

    private Collider thingClicked = null;
    public GameGrid GameGridInstance;

    // Use this for initialization
    void Start () {
		Go(NothingSelectedStart(), null);
	}
    
    private IEnumerator NothingSelectedStart()
    {
        yield return new WaitUntil(() => Input.GetButtonDown("Fire1"));

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && 
            hit.collider.gameObject.GetComponent<GridCharacter>() != null &&
            hit.collider.gameObject.GetComponent<GridCharacter>().UsedThisTurn != true &&
            hit.collider.gameObject.GetComponent<GridCharacter>().teamIndex != -1)//really replace this with some tag check
        {
            //print(hit.collider.name);
            thingClicked = hit.collider;
            Go(PlaceObjectStart(), null);
            yield break;
        }

        // if nothing was selected, restart the state
        Go(NothingSelectedStart(), null);
    }

    private IEnumerator PlaceObjectStart()
    {
        GameGridInstance.DisplayInfluence(thingClicked.gameObject.GetComponent<GridCharacter>());

        thingClicked.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        yield return new WaitUntil(() => Input.GetButtonUp("Fire1"));
        yield return new WaitUntil(() => Input.GetButtonDown("Fire1"));

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if ((Physics.Raycast(ray, out hit) && hit.collider.gameObject.GetComponent<GridSlot>() &&
            GameGridInstance.IsSlotInInfluence(hit.collider.gameObject.GetComponent<GridSlot>(), thingClicked.gameObject.GetComponent<GridCharacter>())))
        {
            GameGridInstance.ClearAllInfluence();
            // move the object

            // localScale should be stored in the grid char and accessed. 
            thingClicked.transform.position = new Vector3(Mathf.RoundToInt(hit.point.x), thingClicked.transform.localScale.y * 0.5f, Mathf.RoundToInt(hit.point.z));
            

            // this should all be wrappd in a gridchar func really...
            thingClicked.gameObject.GetComponent<GridCharacter>().UsedThisTurn = true;
            thingClicked.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);


            thingClicked = null;
            yield return new WaitUntil(() => Input.GetButtonUp("Fire1"));
            Go(NothingSelectedStart(), null);
            yield break;
        }
        else if (Physics.Raycast(ray, out hit) && 
            hit.collider.gameObject.GetComponent<GridCharacter>() != null &&
            hit.collider.gameObject.GetComponent<GridCharacter>().UsedThisTurn != true &&
            hit.collider.gameObject.GetComponent<GridCharacter>().teamIndex != -1)//really replace this with some tag check
        {
            //print(hit.collider.name);
            thingClicked.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            thingClicked = hit.collider;
            
            Go(PlaceObjectStart(), null);
            yield break;
        }

        // if nothing was selected, restart the state
        Go(PlaceObjectStart(), null);
    }
}
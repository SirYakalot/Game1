using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSlot
{
    public GridCharacter gridChar = null;
    public GameObject floorPiece; 

    // Start is called before the first frame update
    public void Initialise(Vector3 position)
    {
        floorPiece = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        floorPiece.transform.localScale = new Vector3(0.5f, 0.1f, 0.5f);
        floorPiece.transform.position = position;
    }
}

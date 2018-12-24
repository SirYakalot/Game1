using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    private List<List<GridSlot>> gridIndexes = new List<List<GridSlot>>();
    // provide a function that lets you input a grid index, and get back 
    // neighbours
    
    // need to overload this to provide an input that is an influence shape
    // how do you define influence shapes? dunno. doitinabit
    void Start () 
    {
        int gridSizeX = 10;
        int gridSizeZ = 10;

        for (int x = 0; x < gridSizeX; x++)
        {
            gridIndexes.Add(new List<GridSlot>());
            for (int z = 0; z < gridSizeZ; z++)
            {
                float newX = (x - (gridSizeX / 2));
                float newZ = (z - (gridSizeZ / 2));

                gridIndexes[x].Add(new GridSlot());
                gridIndexes[x][z].Initialise(new Vector3(newX, 0, newZ));
            }
        }
    }
    
    // you know what would be LESS SHIT than this? each slot keeping references to their neighbours
    public bool IsImmediateNeighbour(GridSlot character, GridSlot target)
    {
        if ((character.gridChar.gridX == target.gridChar.gridX) && 
            ((character.gridChar.gridZ == target.gridChar.gridZ - 1) || (character.gridChar.gridZ == target.gridChar.gridZ + 1)))
        {
            return true;
        }
        else if ((character.gridChar.gridZ == target.gridChar.gridZ) && 
            ((character.gridChar.gridX == target.gridChar.gridX - 1) || (character.gridChar.gridX == target.gridChar.gridX + 1)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

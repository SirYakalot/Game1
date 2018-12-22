using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    private List<List<GridCharacter>> gridIndexes = new List<List<GridCharacter>>();
    // provide a function that lets you input a grid index, and get back 
    // neighbours
    
    // need to overload this to provide an input that is an influence shape
    // how do you define influence shapes? dunno. doitinabit
    void Start () 
    {
        for (int x = 0; x < 10; x++)
        {
            gridIndexes.Add(new List<GridCharacter>());
            for (int z = 0; z < 10; z++)
            {
                gridIndexes[x].Add(null);
            }
        }
    }
    public bool IsImmediateNeighbour(GridCharacter character, GridCharacter target)
    {
        if ((character.gridX == target.gridX) && 
            ((character.gridZ == target.gridZ - 1) || (character.gridZ == target.gridZ + 1)))
        {
            return true;
        }
        else if ((character.gridZ == target.gridZ) && 
            ((character.gridX == target.gridX - 1) || (character.gridX == target.gridX + 1)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

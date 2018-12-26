using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    private List<List<GridSlot>> gridIndexes = new List<List<GridSlot>>();
    public GameObject GridPiece;
    public Material baseMaterial;
    public Material influenceMaterial;
    // provide a function that lets you input a grid index, and get back 
    // neighbours
    
    // need to overload this to provide an input that is an influence shape
    // how do you define influence shapes? dunno. doitinabit
    void Start () 
    {
        int gridSizeX = 10;
        int gridSizeZ = 20;

        for (int x = 0; x < gridSizeX; x++)
        {
            gridIndexes.Add(new List<GridSlot>());
            for (int z = 0; z < gridSizeZ; z++)
            {
                float newX = (x - (gridSizeX / 2));
                float newZ = (z - (gridSizeZ / 2));

                gridIndexes[x].Add(Instantiate(GridPiece, new Vector3(newX, 0, newZ), Quaternion.identity).GetComponent<GridSlot>());
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

    public void ClearAllInfluence()
    {
        // replace this with a refereced list of slots, sorted by slot ID
        foreach (List<GridSlot> slotList in gridIndexes)
        {
            foreach (GridSlot slot in slotList)
            {
                Renderer r = slot.floorPiece.GetComponent<Renderer>();
                r.material = baseMaterial;
            }
        }
    }

    public void DisplayInfluence(GridCharacter character)
    {
        // replace this with a refereced list of slots, sorted by slot ID
        foreach (List<GridSlot> slotList in gridIndexes)
        {
            foreach (GridSlot slot in slotList)
            {
                Renderer r = slot.floorPiece.GetComponent<Renderer>();
                r.material = baseMaterial;
            }
        }

        List<GridSlot> slots = GetInfluence(character);

        foreach (GridSlot slot in slots)
        {
            Renderer r = slot.floorPiece.GetComponent<Renderer>();
            r.material = influenceMaterial;
        }
    }

    public bool IsSlotInInfluence(GridSlot slot, GridCharacter character)
    {
        List<GridSlot> slots = GetInfluence(character);
            
        return slots.Contains(slot);
    }

    public List<GridSlot> GetInfluence(GridCharacter character)
    {
        int x = character.gridX;
        int z = character.gridZ;

        Vector3 charPos = character.transform.position;
        List<GridSlot> slotsInInfluence = new List<GridSlot>();

        // there's gotta be a better way to do this..
        foreach (List<GridSlot> slotList in gridIndexes)
        {
            foreach (GridSlot slot in slotList)
            {
                
                Vector3 slotPos = slot.floorPiece.transform.position;

                if (Vector3.Distance(charPos, slotPos) <= character.gridInfluence)
                {
                    slotsInInfluence.Add(slot);
                }
            }
        }

        return slotsInInfluence;
    }
}

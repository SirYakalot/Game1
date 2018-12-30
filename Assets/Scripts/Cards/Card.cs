using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ok as a test... have some boring basic cards... deal
public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isCharacterActionCard = false;
    public bool IsCharacterActionCard { get; }
    private bool isSpawnCard = false;
    public bool IsSpawnCard { get; }

    public virtual void DoAction(GridCharacter character) {}

    public virtual void SpawnCharacter(GridSlot slot) {}
}

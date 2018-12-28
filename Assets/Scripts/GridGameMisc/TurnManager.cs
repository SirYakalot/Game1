using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : StateScript {
    public bool turnComplete = false;
    public bool playerTurn = true;
	// Use this for initialization
	void Start () {
		Go(PlayerTurn(), null);
	}
	private IEnumerator PlayerTurn()
    {
        playerTurn = true;
        turnComplete = false;
        yield return new WaitUntil(() => turnComplete);
        Go(EnemyTurn(), null);
    }

    private IEnumerator EnemyTurn()
    {
        playerTurn = false;
        turnComplete = false;
        yield return new WaitUntil(() => turnComplete);
        Go(PlayerTurn(), null);
    }
}

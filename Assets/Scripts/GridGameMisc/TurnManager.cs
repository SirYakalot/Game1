// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.EventSystems;

// public class TurnManager : StateScript, IPointerClickHandler
// {
//     public bool turnComplete = false;
//     public bool playerTurn = true;
// 	// Use this for initialization
// 	void Start () {
// 		Go(PlayerTurn(), null);
// 	}
// 	private IEnumerator PlayerTurn()
//     {
//         // this should all be wrappd in a gridchar func really...
//         // need some grid game globals. magic lists. can't be fucked to do this right now
//         thingClicked.gameObject.GetComponent<GridCharacter>().UsedThisTurn = true;
//         thingClicked.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
//         playerTurn = true;
//         turnComplete = false;
//         yield return new WaitUntil(() => turnComplete);
//         Go(EnemyTurn(), null);
//     }

//     //Detect if a click occurs
//     public void OnPointerClick(PointerEventData pointerEventData)
//     {
//         turnComplete = true;
//     }

//     private IEnumerator EnemyTurn()
//     {
//         playerTurn = false;
//         turnComplete = false;
//         // yield return new WaitUntil(() => turnComplete);
//         Go(PlayerTurn(), null);
//         yield return 0;
//     }
// }

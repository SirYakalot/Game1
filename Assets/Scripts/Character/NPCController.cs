using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : StateScript {

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 1.5f;
		Go(SearchToPoint());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator FindNewPoint()
    {
        destPoint = (destPoint + 1) % points.Length;
        Go(SearchToPoint());
        yield return 0;
    }

    private IEnumerator SearchToPoint()
    {
        agent.destination = points[destPoint].position;
        yield return new WaitUntil(() => ScriptFuncs.AgentReachedDestination(agent));
        Go(Idle());
    }

    private IEnumerator Idle()
    {
        yield return new WaitForSeconds(3.0f);
        Go(FindNewPoint());
    }

    public void Interrupt(Transform character)
    {
        Go(TalkingToCharacter(character));
    }
    private IEnumerator TalkingToCharacter(Transform character)
    {
        agent.destination = character.position;
        agent.stoppingDistance = 2.0f;
        yield return new WaitUntil(() => ScriptFuncs.AgentReachedDestination(agent));
        yield return new WaitForSeconds(3.0f);
        Go(FindNewPoint());
    }
}

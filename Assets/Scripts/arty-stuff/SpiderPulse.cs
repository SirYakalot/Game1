using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderPulse : MonoBehaviour {

    //Dictionary<int, Dot> allDots = new Dictionary<int, Dot>();
    private List<Dot> activeDots = new List<Dot>();
    private List<Dot> allDots = new List<Dot>(0);
    protected IEnumerator coro;
    //private List<Dot> frontierDots = new List<Dot>();
	// Use this for initialization
    public int maxWebLinks = 30;

    private void ExpandIntoAdjacent ()
    {
        bool foundLeft = false;
        bool foundRight = false;
        bool foundUp = false;
        bool foundDown = false;

        Dot tDot = activeDots[Random.Range(0, activeDots.Count - 1)];
       
        foreach (Dot d in allDots)
        {
            if ((tDot._position + new Vector3(1,0,0)) == d._position) 
            {
                foundRight = true;
            }
            if ((tDot._position + new Vector3(-1,0,0)) == d._position) 
            {
                foundLeft = true;
            }
            if ((tDot._position + new Vector3(0,1,0)) == d._position) 
            {
                foundUp = true;
            }
            if ((tDot._position + new Vector3(0,-1,0)) == d._position) 
            {
                foundDown = true;
            }
        }

        // activeDots.Add(inspectingDot);
        // frontierDots.Remove(inspectingDot);
        // activeDots[0].adjacentDots.Remove(inspectingDot);
        // foreach (Dot d in frontierDots)
        // {
        //     if ((inspectingDot._position + new Vector3(1,0,0)) == d._position) 
        //     {
        //         foundRight = true;
        //     }
        //     if ((inspectingDot._position + new Vector3(-1,0,0)) == d._position) 
        //     {
        //         foundLeft = true;
        //     }
        //     if ((inspectingDot._position + new Vector3(0,1,0)) == d._position) 
        //     {
        //         foundUp = true;
        //     }
        //     if ((inspectingDot._position + new Vector3(0,-1,0)) == d._position) 
        //     {
        //         foundDown = true;
        //     }
        // }

        if (!foundRight) 
        {
            Dot d = new Dot(tDot._position + new Vector3(1,0,0), tDot);
            activeDots.Add(d);
            allDots.Add(d);
            foundRight = true;
            // frontierDots.Add(d);
        }
        else if (!foundLeft) 
        {
            Dot d = new Dot(tDot._position + new Vector3(-1,0,0), tDot);
            activeDots.Add(d);
            allDots.Add(d);
            foundLeft = true;
            // frontierDots.Add(d);
        }
        else if (!foundUp) 
        {
            Dot d = new Dot(tDot._position + new Vector3(0,1,0), tDot);
            activeDots.Add(d);
            allDots.Add(d);
            foundUp = true;
            // frontierDots.Add(d);
        }
        else if (!foundDown) 
        {
            Dot d = new Dot(tDot._position + new Vector3(0,-1,0), tDot);
            activeDots.Add(d);
            allDots.Add(d);
            foundDown = true;
            // frontierDots.Add(d);
        }

        if (foundLeft && foundRight && foundUp && foundDown)
        {
            activeDots.Remove(tDot);
        }
    }

    private void NewFrontier()
    {

    }

    private IEnumerator webLoop()
    {
        
        while (true)
        {
            int linkCount = Random.Range(10, maxWebLinks);
            while (linkCount > 0)
            {
                ExpandIntoAdjacent();
                yield return new WaitForSeconds(0.01f);
                linkCount--;
            }
            yield return new WaitForSeconds(1.0f);
            allDots.Clear();
            activeDots.Clear();
            activeDots.Add(new Dot(new Vector3(0,0,0)));
            allDots.Add(activeDots[0]);
        }
    }

	void Start () {
        activeDots.Add(new Dot(new Vector3(0,0,0)));
        allDots.Add(activeDots[0]);
        //allDots.Add(00, newDot);

        // Dot fDot1 = new Dot(new Vector3(1,0,0), activeDots[0]);
        // Dot fDot2 = new Dot(new Vector3(-1,0,0), activeDots[0]);
        // Dot fDot3 = new Dot(new Vector3(0,1,0), activeDots[0]);
        // Dot fDot4 = new Dot(new Vector3(0,-1,0), activeDots[0]);

        // frontierDots.Add(fDot1);
        // frontierDots.Add(fDot2);
        // frontierDots.Add(fDot3);
        // frontierDots.Add(fDot4);

        // activeDots[0].adjacentDots.Add(fDot1);
        // activeDots[0].adjacentDots.Add(fDot2);
        // activeDots[0].adjacentDots.Add(fDot3);
        // activeDots[0].adjacentDots.Add(fDot4);

        coro = webLoop();
        StartCoroutine(coro);
	}
	
	// Update is called once per frame
	void Update () {
        foreach (Dot d in allDots)
        {
            d.Update();
        }
	}
}

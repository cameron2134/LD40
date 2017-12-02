using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : Creature
{

    public Vector2 wanderRangeX, wanderRangeY;

    private Vector2 moveToPos;
    private bool isMoving;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (moveToPos == Vector2.zero)
	    {
	        isMoving = true;
	        moveToPos = Utils.RandomVectorInBox(wanderRangeX, wanderRangeY);
	    }

	    else if (isMoving && new Vector2(transform.position.x, transform.position.y) == moveToPos)
	    {
	        isMoving = false;
	        StartCoroutine(StopAndWait());
	    }

        if (isMoving)
	        transform.position = Vector2.MoveTowards(transform.position, moveToPos, moveSpeed * Time.deltaTime);
	}





    IEnumerator StopAndWait()
    {
        yield return new WaitForSeconds(Random.Range(1, 3));

        moveToPos = Utils.RandomVectorInBox(wanderRangeX, wanderRangeY);
        isMoving = true;
    }
}

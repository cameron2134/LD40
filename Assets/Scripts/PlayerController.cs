using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Skeleton
{

    private float moveX, moveY;


	void Start () {
		
	}
	

	void Update () {
	    #region Player Movement
	    moveX = moveY = 0;

	    // Movement
	    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
	    {
	        moveX = -1;
	        moveY = 0;

	        if (Input.GetKey(KeyCode.S))
	            moveY = -1;

	    }

	    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
	    {
	        moveX = 1;
	        moveY = 0;

	        if (Input.GetKey(KeyCode.S))
	            moveY = 1;
	    }

	    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
	    {
	        moveY = 1;
	        moveX = 0;

	        if (Input.GetKey(KeyCode.A))
	            moveX = -1;

	        else if (Input.GetKey(KeyCode.D))
	            moveX = 1;
	    }

	    if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
	    {
	        moveY = -1;
	        moveX = 0;

	        if (Input.GetKey(KeyCode.A))
	            moveX = -1;

	        else if (Input.GetKey(KeyCode.D))
	            moveX = 1;
	    }

	    #endregion
    }

    void FixedUpdate()
    {
        creatureBody.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
    }

}

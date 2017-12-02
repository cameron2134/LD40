using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : Skeleton
{

    public Vector2 wanderRangeX, wanderRangeY;

    private Vector2 moveToPos;
    private bool isMoving, isIdling, hasDecision;


	void Start ()
	{
	    isIdling = true;
	}

	void Update ()
	{
	    if (moveToPos == Vector2.zero)
	    {
	        isMoving = true;
	        moveToPos = Utils.RandomVectorInBox(wanderRangeX, wanderRangeY);
	    }


        //if (isIdling)
            Move();
	}


    void FixedUpdate()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 10);
        //Debug.DrawLine(this.gameObject.transform.position, new Vector2(this.transform.position.x + 10, this.transform.position.y), Color.red, 1, false);

        int i = 0;
        while (i < hitColliders.Length)
        {

            if (hitColliders[i].tag == "Player" || (hitColliders[i].tag == "Skeleton" && hitColliders[i].gameObject != gameObject) || hitColliders[i].tag == "Body Part")
            {
               
                isIdling = false;
                isMoving = true;

                if (!hasDecision)
                    MakeDecision(hitColliders[i].gameObject);
            }

            else
            {
                isIdling = true;
            }

            i++;
        }
    }



    private void MakeDecision(GameObject obj)
    {
        var chance = Random.value;

        if (totalBodyParts != 0)
        {
            if (totalBodyParts < (MAX_BODY_PARTS / 2) && chance > 0.7)
            {
                // Lower chance to go for skeleton
                chance = Random.value;
                if (chance > 0.8)
                {
                    if (obj.tag == "Skeleton")
                        moveToPos = obj.transform.position;
                }

                else
                {
                    if (obj.tag == "Body Part")
                        moveToPos = obj.transform.position;
                }

            }

            else if ((totalBodyParts >= (MAX_BODY_PARTS / 2) && totalBodyParts != MAX_BODY_PARTS) && chance > 0.3)
            {
                chance = Random.value;
                if (chance > 0.5)
                {
                    if (obj.tag == "Skeleton")
                        moveToPos = obj.transform.position;
                }

                else
                {
                    if (obj.tag == "Body Part")
                        moveToPos = obj.transform.position;
                }
            }

            else if (totalBodyParts == MAX_BODY_PARTS)
            {
                // 100% chance t oattack
                if (obj.tag == "Skeleton" || obj.tag == "Player")
                {
                    Debug.Log("finding player " + obj.name);
                    moveToPos = obj.transform.position;
                }
            }
        }

        else
        {
            // Pick up body parts
            if (obj.tag == "Body Part")
                moveToPos = obj.transform.position;
        }

        hasDecision = true;
    }



    private void Move()
    {
        if (isMoving)
        {
            if (new Vector2(transform.position.x, transform.position.y) != moveToPos)
                transform.position = Vector2.MoveTowards(transform.position, moveToPos, moveSpeed * Time.deltaTime);
            else
            {
                
                isMoving = false;
                if (hasDecision)
                    hasDecision = false;
                if (isIdling)
                    StartCoroutine(StopAndWait());
            }
            
        }
    }



    IEnumerator StopAndWait()
    {
        yield return new WaitForSeconds(Random.Range(1, 3));

        moveToPos = Utils.RandomVectorInBox(wanderRangeX, wanderRangeY);
        isMoving = true;
    }
}

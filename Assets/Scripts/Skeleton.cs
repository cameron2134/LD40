using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Creature
{

    private const int MAX_BODY_PARTS = 9;

    protected int totalBodyParts;




    public int TotalBodyParts {
        get { return totalBodyParts; }
        protected set { totalBodyParts = value; }
    }


    protected virtual void Start () {
		
	}
	

	protected virtual void Update () {
		
	}


    protected virtual void ThrowBodyPart()
    {
        
    }


    // Transfer body parts on collision
    protected virtual void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Body Part" && totalBodyParts < MAX_BODY_PARTS)
        {
            Debug.Log("Picked up body part");
            totalBodyParts++;
            GameManager.Instance.OnBodyPartsIncreased(1);
            GameManager.Instance.DestroyObj(col.gameObject);
        }

        else if (col.gameObject.tag == "Skeleton")
        {
            // Detract body part from other skeleton and add to self
        }
    } 
}

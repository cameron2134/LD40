using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Creature {

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
        
    } 
}

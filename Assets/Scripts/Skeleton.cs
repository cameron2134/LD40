using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Creature
{

    protected const int MAX_BODY_PARTS = 10;

    protected int totalBodyParts;

    protected bool canTransferPart;




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


    public void TransferBodyPart(int num)
    {
        totalBodyParts++;
    }


    // Transfer body parts on collision
    protected virtual void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Body Part" && totalBodyParts < MAX_BODY_PARTS)
        {
            totalBodyParts++;
            GameManager.Instance.DestroyObj(col.gameObject);
        }

        else if (col.gameObject.tag == "Skeleton")
        {
            // Detract body part from other skeleton and add to self - transfer 1 body part per time contacted - wait 0.5f so its balanced
            if (canTransferPart && totalBodyParts > 0)
            {
                totalBodyParts--;
                col.gameObject.GetComponent<Skeleton>().TransferBodyPart(1);
                StartCoroutine(TransferCooldown());
            }
        }
    }


    IEnumerator TransferCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        canTransferPart = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{

    private string partType; // Randomized out of all possible body parts



	void Start ()
	{
	    partType = GameManager.Instance.GetBodyPart();
        
	}

    void OnEnable()
    {
        StartCoroutine(Expire());
    }


    IEnumerator Expire()
    {
        yield return new WaitForSeconds(10);
        GameManager.Instance.DestroyObj(gameObject);
    }
}

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
	
}

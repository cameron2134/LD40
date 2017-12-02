using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;


    private string[] bodyParts = new string[] { "Leg", "Arm", "Face", "Torso", "Foot", "Hand" };



    public string GetBodyPart()
    {
        return bodyParts[Random.Range(0, bodyParts.Length-1)];
    }




    // events etc


	// Use this for initialization
	void Start ()
	{
        if (Instance == null)
	        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
